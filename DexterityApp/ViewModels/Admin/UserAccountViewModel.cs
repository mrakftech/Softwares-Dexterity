using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using AutoMapper;
using DevExpress.Mvvm;
using DexterityApp.Helpers;
using Features.Contracts.Repositroy;
using Services.Contracts.Repositroy;
using Services.Features.UserAccounts.Specifications;
using Shared.Constants.Role;
using Shared.Requests.UserAccounts;
using Shared.Responses.UserAccounts;

namespace DexterityApp.ViewModels.Admin
{
    public class UserAccountViewModel : Observable, INotifyPropertyChanged
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private ObservableCollection<UserResponse> _users = [];
        public ICommand GetUsersCommand { get; set; }
        public ICommand CreateUsersCommand { get; set; }
        public CreateUserRequest User { get; set; } = new();

        public List<string> Roles { get; set; } = RoleConstants.Roles;
        public List<string> UserTypes { get; set; } = UserTypeConstants.UserTypes;


        public ObservableCollection<UserResponse> Users
        {
            get { return _users; }
            set
            {
                if (value != _users)
                {
                    _users = value;
                    NotifyPropertyChanged("Users");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public UserAccountViewModel(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            GetUsersCommand = new RelayCommand(GetAllUsers);
            CreateUsersCommand = new RelayCommand(CreateUser);
        }

        private void GetAllUsers()
        {
            GetUsers();
        }

        private void CreateUser()
        {
            Task.Run(async () =>
            {
                if (!IDataErrorInfoHelper.HasErrors(User))
                {
                    var result = await _unitOfWork.User.SaveUser(User);
                    if (result.Succeeded)
                    {
                        MessageBoxHelper.ShowSuccessMessage(result.Messages.First());
                    }
                    else
                    {
                        MessageBoxHelper.ShowFailMessage(result.Messages.First());
                    }
                }
                else
                {
                    MessageBoxHelper.ShowFailMessage(User.Error);
                }
            });
        }

        private void DeleteUser(Guid id)
        {
            Task.Run(async () =>
            {
                var dialogResult = MessageBox.Show(@"Do you want to continue?", @"Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var result = await _unitOfWork.User.DeleteUser(id);
                    if (result.Succeeded)
                    {
                        MessageBox.Show(result.Messages.First(), @"Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(result.Messages.First(), @"Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            });
        }

        private void GetUsers()
        {
            var listUser = new ObservableCollection<UserResponse>();
            var users = _mapper.Map<List<UserResponse>>(_unitOfWork.User.Find(new UsersWithRolesSpecification()));
            foreach (var user in users)
            {
                listUser.Add(user);
            }

            Users = listUser;

        }
    }
}