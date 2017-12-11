using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Arrays for holding Members, Member types and filtered Members
        Member[] memberArray = new Member[4];
        MemberType[] typeArray = new MemberType[4];
        Member[] filteredMembers = new Member[4];

        //Declare member types
        MemberType Full = new MemberType("Full");
        MemberType OffPeak = new MemberType("Off Peak");
        MemberType Student = new MemberType("Student");
        MemberType OAP = new MemberType("OAP");

        public MainWindow()
        {
            InitializeComponent();

            //Populate member type array
            typeArray[0] = Full;
            typeArray[1] = OffPeak;
            typeArray[2] = Student;
            typeArray[3] = OAP;

            //Create random
            Random random = new Random();
            
            //Create members and populate array with them
            Member m1 = new Member("Joe Bloggs",0861234567,"1 O'Connell Street, Sligo",Full,random.Next(2000,2016));
            Member m2 = new Member("Mary Bloggs",0867654321,"2, Clare Street, Dublin",OffPeak,random.Next(2000,2016));
            Member m3 = new Member("Jim Bloggs",0879876543,"3, Pier Road, Cork",Student,random.Next(2000,2016));
            Member m4 = new Member("Jesse Bloggs",0873456789,"4, Deer Hill, Donegal",OAP,random.Next(2000,2016));
            memberArray[0] = m1;
            memberArray[1] = m2;
            memberArray[2] = m3;
            memberArray[3] = m4;

            //Populate combo box with member types
            string[] typesList = { "All", "Full", "Off Peak", "Student", "OAP" };
            CboType.ItemsSource = typesList;
            CboType.SelectedIndex = 0;

            //Populate listbox with existing members
            LstBoxMembers.ItemsSource = memberArray;
        }

        /*When the member selection is changed, display their information*/
        public void LstBoxMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Get Selected member
            Member selectedMember = (Member)LstBoxMembers.SelectedItem;

            //If there is a selected member, display their data
            if (selectedMember != null)
            {
                //Display their information
                DisplayMemberName.Text = selectedMember.Name.ToString();
                DisplayMemberPhone.Text = selectedMember.Phone.ToString();
                DisplayMemberAddress.Text = selectedMember.Address.ToString();
                DisplayMemberType.Text = selectedMember.Type.ToString();
                DisplayMemberYear.Text = selectedMember.YearJoined.ToString();
            }
            //If there is no selected member, clear the boxes
            else
            {
                DisplayMemberName.Text = "";
                DisplayMemberPhone.Text = "";
                DisplayMemberAddress.Text = "";
                DisplayMemberType.Text = "";
                DisplayMemberYear.Text = "";
            }

        }

        /* When the combo box selection is changed, filter the members in the listbox*/
        private void CboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Clear Member listbox
            LstBoxMembers.ItemsSource = "";

            //Counts how many members are in the filtered array
            int x = 0;

            ////Gets which index is selected in the combo box and checks if each member matches it
            //If it matches, it gets added to the filtered members array
            //All
            if (CboType.SelectedIndex == 0)
            {
                LstBoxMembers.ItemsSource = memberArray;
            }
            //Full
            else if (CboType.SelectedIndex == 1)
            {
                searchMembersType(Full);
                LstBoxMembers.ItemsSource = filteredMembers;
            }
            //Off Peak
            else if (CboType.SelectedIndex == 2)
            {
                searchMembersType(OffPeak);
                LstBoxMembers.ItemsSource = filteredMembers;
            }
            //Student
            else if (CboType.SelectedIndex == 3)
            {
                searchMembersType(Student);
                LstBoxMembers.ItemsSource = filteredMembers;
            }
            //OAP
            else if (CboType.SelectedIndex == 4)
            {
                searchMembersType(OAP);
                LstBoxMembers.ItemsSource = filteredMembers;
            }
        }
        private void searchMembersType(MemberType selectedType)
        {
            //Counter for filtered array index
            int x = 0;

            //Loop through members and see which are of the right type
            foreach (Member currentMember in memberArray)
            {
                //If the members type matches the selected type
                if (currentMember.Type == selectedType)
                {
                    filteredMembers[x] = currentMember;
                    x++;
                }
            }
        }

        /* When the search button is clicked, search through all members                *
         * to see if the searched string in contained in the name of an existing user.  *
         * If it is, display the user in the members listbox                            */
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //Clear the member listbox
            LstBoxMembers.ItemsSource = "";
            Array.Clear(filteredMembers,0,filteredMembers.Length);

            //Get the searched text
            string searchTerm = TxtSearchBox.Text;
            
            //Counter for index of filtered members array
            int x = 0;

            //Loop through all members and check their name against the search terms
            //If its there, add it to the filtered array
            foreach (Member currentMember in memberArray)
            {
                //If the searched string is in the current members name and the current member is already in the member list
                if (currentMember.Name.Contains(searchTerm))
                {
                    filteredMembers[x] = currentMember;
                    x++;

                    LstBoxMembers.ItemsSource = filteredMembers;
                }
            }
        }
    }
}
