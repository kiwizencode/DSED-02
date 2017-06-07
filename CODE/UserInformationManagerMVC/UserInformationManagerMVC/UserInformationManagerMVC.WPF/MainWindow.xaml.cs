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
using UserInformationManagerMVC.Controller;
using UserInformationManagerMVC.Model;
using System.Collections;

namespace UserInformationManagerMVC.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IUsersView
    {
        UsersController _controller;

        public string ID
        {
            get { return this.txtID.Text; }
            set { this.txtID.Text = value; }
        }
        public string FirstName
        {
            get { return this.txtFirstName.Text; }
            set { this.txtFirstName.Text = value; }
        }
        public string LastName
        {
            get { return this.txtLastName.Text; }
            set { this.txtLastName.Text = value; }
        }
        public string Department
        {
            get { return this.txtDepartment.Text; }
            set { this.txtDepartment.Text = value; }
        }
        public User.SexOfPerson Sex
        {
            get
            {
                if (this.rdMale.IsChecked == true)
                    return User.SexOfPerson.Male;
                else
                    return User.SexOfPerson.Female;
            }
            set
            {
                if (value == User.SexOfPerson.Male)
                    this.rdMale.IsChecked = true;
                else
                    this.rdFemale.IsChecked = true;
            }
        }
        public bool CanModifyID { set { this.txtID.IsEnabled = value; } }


        public MainWindow()
        {
            InitializeComponent();

            GenerateDummyData();
        }

        private void GenerateDummyData()
        {
            IList users = new ArrayList();
            users.Add(new User("Vladimir", "Putin", "122", "Government of Russia", User.SexOfPerson.Male));
            users.Add(new User("Barack", "Obama", "123", "Government of USA", User.SexOfPerson.Male));
            users.Add(new User("Stephen", "Harper", "124", "Government of Canada", User.SexOfPerson.Male));
            users.Add(new User("Jean", "Charest", "125", "Government of Quebec", User.SexOfPerson.Male));
            users.Add(new User("David", "Cameron", "126", "Government of United Kingdom", User.SexOfPerson.Male));
            users.Add(new User("Angela", "Merkel", "127", "Government of Germany", User.SexOfPerson.Female));
            users.Add(new User("Nikolas", "Sarkozy", "128", "Government of France", User.SexOfPerson.Male));
            users.Add(new User("Silvio", "Berlusconi", "129", "Government of Italy", User.SexOfPerson.Male));
            users.Add(new User("Yoshihiko", "Noda", "130", "Government of Japan", User.SexOfPerson.Male));
            _controller = new UsersController(this, users);
            _controller.LoadView();
        }


        #region Events raised  back to controller
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this._controller.AddNewUser();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            this._controller.RemoveUser();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            this._controller.Save();
        }
        private void grdUsers_SelectedIndexChanged(object sender, EventArgs e)
        {           
            if (this.grdUsers.SelectedItems.Count > 0)
            //    this._controller.SelectedUserChanged(this.grdUsers.SelectedItems[0].Text);
            {
                dynamic user = this.grdUsers.SelectedItem;
                this._controller.SelectedUserChanged(user.ID);
            }
                
        }
        #endregion

        #region ICatalogView implementation
        public void SetController(UsersController controller)
        {
            //_controller = controller;
        }


        public void ClearGrid()
        {
            // Define columns in grid for Win Form
            //this.grdUsers.Columns.Clear();
            //this.grdUsers.Columns.Add("Id", 150, HorizontalAlignment.Left);
            //this.grdUsers.Columns.Add("First Name", 150, HorizontalAlignment.Left);
            //this.grdUsers.Columns.Add("Lastst Name", 150, HorizontalAlignment.Left);
            //this.grdUsers.Columns.Add("Department", 150, HorizontalAlignment.Left);
            //this.grdUsers.Columns.Add("Sex", 50, HorizontalAlignment.Left);

            // Add rows to grid
            this.grdUsers.Items.Clear();
        }

        public string GetIdOfSelectedUserInGrid()
        {
            //if (this.grdUsers.SelectedItems.Count > 0)
            //    return this.grdUsers.SelectedItems[0].Text;
            if( this.grdUsers.SelectedIndex > 0)
            {
                dynamic user = this.grdUsers.SelectedItem;
                return user.ID;
            }
            else
                return "";
        }

        public void RemoveUserFromGrid(User user)
        {
            User rowToRemove = null;

            foreach (User row in this.grdUsers.Items)
            {
                
                if (row.ID == user.ID)
                {
                    rowToRemove = row;
                }
            }

            if (rowToRemove != null)
            {
                this.grdUsers.Items.Remove(rowToRemove);
                this.grdUsers.Focus();
            }
        }

        public void AddUserToGrid(User user)
        {
            this.grdUsers.Items.Add(user);
            /*
            ListViewItem parent;
            parent = this.grdUsers.Items.Add(user.ID);
            parent.SubItems.Add(user.FirstName);
            parent.SubItems.Add(user.LastName);
            parent.SubItems.Add(user.Department);
            parent.SubItems.Add(Enum.GetName(typeof(User.SexOfPerson), user.Sex));
            */
        }

        public void SetSelectedUserInGrid(User user)
        {
      
            //foreach (ListViewItem row in this.grdUsers.Items)
            for(int i = 0; i < this.grdUsers.Items.Count; i++)
            {
                dynamic userdata = this.grdUsers.Items[i];
                if (userdata.ID == user.ID)
                {
                    //row.Selected = true;
                    this.grdUsers.SelectedIndex = i;
                    break;
                }
            }
        }

        public void UpdateGridWithChangedUser(User user)
        {
            User rowToUpdate = null;

            foreach (User row in this.grdUsers.Items)
            {
                if (row.ID == user.ID)
                {
                    rowToUpdate = row;
                }
            }

            if (rowToUpdate != null)
            {
                rowToUpdate.ID = user.ID;
                rowToUpdate.FirstName = user.FirstName;
                rowToUpdate.LastName = user.LastName;
                rowToUpdate.Department = user.Department;
                rowToUpdate.Sex = user.Sex; //Enum.GetName(typeof(User.SexOfPerson), user.Sex);
                grdUsers.Items.Refresh();
            }
        }

        #endregion
    }
}
