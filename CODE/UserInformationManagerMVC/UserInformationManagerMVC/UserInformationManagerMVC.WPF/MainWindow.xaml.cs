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

        UsersController _controller;

        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Department { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public User.SexOfPerson Sex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool CanModifyID { set => throw new NotImplementedException(); }

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
        {/*
            if (this.grdUsers.SelectedItems.Count > 0)
                this._controller.SelectedUserChanged(this.grdUsers.SelectedItems[0].Text);
                */
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
            throw new NotImplementedException();
        }

        public void RemoveUserFromGrid(User user)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void UpdateGridWithChangedUser(User user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
