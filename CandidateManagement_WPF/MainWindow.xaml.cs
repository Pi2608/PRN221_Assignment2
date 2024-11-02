using Candidate_BussinessObject;
using Candidate_Repository;
using Candidate_Service;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CandidateManagement_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int? RoleId = 0;
        private ICandidateProfileService profileService;
        private IJobPostingService jobPostingService;
        private CandidateProfile selectedCandidate;
        private JobPosting selectedJobPosting;
        public MainWindow(int? roleId)
        {
            InitializeComponent();
            profileService = new CandidateProfileService();
            jobPostingService = new JobPostingService();
            this.RoleId = roleId;
            switch (RoleId)
            {
                case 1:
                    break;
                case 2:
                    this.Add_Btn.IsEnabled = false;
                    break;
                case 3:
                    this.Add_Btn.IsEnabled = false;
                    this.Update_Btn.IsEnabled = false;
                    this.Delete_Btn.IsEnabled = false;
                    this.cmbJobPosting.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void LoadScreen()
        {
            dtgCandidateProfile.ItemsSource = profileService.GetCandidateProfiles();
            dtgCandidateProfile.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.dtgCandidateProfile.ItemsSource = profileService.GetCandidateProfiles();

            this.cmbJobPosting.ItemsSource = jobPostingService.GetJobPosting();
            this.cmbJobPosting.DisplayMemberPath = "JobPostingTitle";
            this.cmbJobPosting.SelectedValuePath = "PostingId";
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCandidate = (CandidateProfile)dtgCandidateProfile.SelectedItem;

            if (selectedCandidate != null)
            {
                txtId.IsEnabled = false;
                txtId.Text = selectedCandidate.CandidateId;
                txtFullname.Text = selectedCandidate.Fullname;
                txtProfileUrl.Text = selectedCandidate.ProfileUrl;
                dpBirthday.SelectedDate = selectedCandidate.Birthday;
                cmbJobPosting.SelectedValue = selectedCandidate.PostingId;
                txtDesc.Text = selectedCandidate.ProfileShortDescription;
            }
        }
        private void ClearFormFields()
        {
            txtId.Clear();
            txtFullname.Clear();
            txtProfileUrl.Clear();
            dpBirthday.SelectedDate = null;
            cmbJobPosting.SelectedIndex = -1;
            txtDesc.Clear();
            dtgCandidateProfile.SelectedItem = null;
            selectedCandidate = null;
            txtId.IsEnabled = true;
        }

        private bool IsCapitalized(string input)
        {
            var words = input.Split(' ');

            foreach (var word in words)
            {
                if (string.IsNullOrEmpty(word) || !char.IsUpper(word[0]) || !word.Substring(1).All(char.IsLower))
                {
                    return false;
                }
            }

            return true;
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newCandidate = new CandidateProfile
                {
                    CandidateId = txtId.Text,
                    Fullname = txtFullname.Text,
                    ProfileUrl = txtProfileUrl.Text,
                    Birthday = dpBirthday.SelectedDate,
                    PostingId = (cmbJobPosting.SelectedItem as JobPosting)?.PostingId,
                    ProfileShortDescription = txtDesc.Text
                };

                if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtFullname.Text) || string.IsNullOrWhiteSpace(txtProfileUrl.Text) || dpBirthday.SelectedDate == null || newCandidate.PostingId == null || string.IsNullOrWhiteSpace(txtDesc.Text))
                {
                    MessageBox.Show("All fields are required!");
                    return;
                } 
                
                if (!Regex.IsMatch(txtId.Text, @"^CANDIDATE\d{4}$"))
                {
                    MessageBox.Show("Candidate ID must have CANDIDATExxxx syntax");
                    return;
                }

                var existedCanadidate = profileService.GetCandidateProfileByID(txtId.Text);

                if (existedCanadidate != null)
                {
                    MessageBox.Show("Candidate ID existed");
                    return;
                }

                if (txtFullname.Text.Length < 12)
                {
                    MessageBox.Show("Candidate name must have more than 12 character");
                    return;
                }
                
                if (!IsCapitalized(txtFullname.Text))
                {
                    MessageBox.Show("Candidate name must be capitalized on each word");
                    return;
                }

                if (txtDesc.Text.Length < 12 || txtDesc.Text.Length > 200)
                {
                    MessageBox.Show($"Description must be 12-200 character. Your description is: {txtDesc.Text.Length} characters");
                    return;
                }

                bool isSuccess = profileService.AddCandidateProfile(newCandidate);

                if (isSuccess) 
                {
                    MessageBox.Show("Succeed");
                    ClearFormFields();
                    LoadScreen();
                } 
                else
                {
                    MessageBox.Show("Fail To Add Candidate");
                }
            } catch (Exception ex)
            {
                MessageBox.Show("An error occur when adding candidate: " + ex.Message);
            }
        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedCandidate != null)
                {
                    selectedCandidate.Fullname = txtFullname.Text;
                    selectedCandidate.ProfileUrl = txtProfileUrl.Text;
                    selectedCandidate.Birthday = dpBirthday.SelectedDate;
                    selectedCandidate.ProfileShortDescription = txtDesc.Text;

                    if (cmbJobPosting.SelectedItem is JobPosting jobPosting)
                    {
                        selectedCandidate.PostingId = jobPosting.PostingId;
                    }

                    if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtFullname.Text) || string.IsNullOrWhiteSpace(txtProfileUrl.Text) || dpBirthday.SelectedDate == null || cmbJobPosting.SelectedValue == null || string.IsNullOrWhiteSpace(txtDesc.Text))
                    {
                        MessageBox.Show("All fields are required!");
                        return;
                    }

                    if (txtFullname.Text.Length < 12)
                    {
                        MessageBox.Show("Candidate name must have more than 12 character");
                        return;
                    }

                    if (!IsCapitalized(txtFullname.Text))
                    {
                        MessageBox.Show("Candidate name must be capitalized on each word");
                        return;
                    }

                    if (txtDesc.Text.Length < 12 || txtDesc.Text.Length > 200)
                    {
                        MessageBox.Show($"Description must be 12-200 character. Your description is: {txtDesc.Text.Length} characters");
                        return;
                    }
                    bool isSuccess = profileService.UpdateCandidateProfile(selectedCandidate.CandidateId, selectedCandidate);
                    if (isSuccess)
                    {
                        MessageBox.Show("Updated");
                        ClearFormFields();
                        LoadScreen();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("An error occur when Updating Candidate profile: " + ex.Message);
            }
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCandidate != null)
            {
                MessageBoxResult rs = MessageBox.Show("Are you sure to delete this candidate", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rs == MessageBoxResult.Yes)
                {
                    profileService.DeleteCandidateProfile(selectedCandidate.CandidateId);
                    ClearFormFields();
                    LoadScreen();
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchList = profileService.SearchCandidates(txtSearchName.Text, dpSearchBirthday.SelectedDate);
            if (!searchList.IsNullOrEmpty()) {
                dtgCandidateProfile.ItemsSource = searchList;
                dtgCandidateProfile.Items.Refresh();
            }
            else
            {
                MessageBox.Show("There are no Candidates that match the infomation!");
            }
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            txtSearchName.Clear();
            dpSearchBirthday.SelectedDate = null;
            LoadScreen();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFormFields();
            txtId.IsEnabled = true;
        }

        private void Close_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}