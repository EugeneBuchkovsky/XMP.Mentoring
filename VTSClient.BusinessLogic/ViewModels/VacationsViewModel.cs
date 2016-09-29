using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VTSClient.BusinessLogic.Services.Interfaces;
//using VTSClient.DataAccess.MockModel;
using VtsMockClient.Domain.Models;

namespace VTSClient.BusinessLogic.ViewModels
{
    public class VacationsViewModel : MvxViewModel
    {
        IVacationsService vocationsService;

        public VacationsViewModel(IVacationsService _vocationsService)
        {
            this.vocationsService = _vocationsService;

            this.menuItems = new List<MenuViewModel>
                               {
                                   new MenuViewModel
                                       {
                                           Section = Enums.MenuItems.AddVcation,
                                           Title = "Add vacation"
                                       },
                                   new MenuViewModel
                                       {
                                           Section = Enums.MenuItems.Vacations,
                                           Title = "Vacations"
                                       },
                                   new MenuViewModel
                                       {
                                           Section =  Enums.MenuItems.LogOn,
                                           Title = "Log out"
                                       },
                                    new MenuViewModel
                                       {
                                           Section =  Enums.MenuItems.SickToday,
                                           Title = "Sick today"
                                       }
                               };

        }

        public override void Start()
        {
            UpdateVacation();
            base.Start();
        }

        public async Task UpdateVacation()
        {
            VocationList = await vocationsService.GetAllVocations();

            return;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private IEnumerable<ShortVacationInfo> vocationList;
        public IEnumerable<ShortVacationInfo> VocationList
        {
            get { return vocationList; }
            set
            {
                vocationList = value;
                RaisePropertyChanged(() => VocationList);
            }
        }

        private ShortVacationInfo selectedVocation;
        public ShortVacationInfo SelectedVocation
        {
            get { return selectedVocation; }
            set
            {
                selectedVocation = value;
                RaisePropertyChanged(() => SelectedVocation);
                ShowSelectedVacationCommand().Execute(null);
            }
        }

        public IMvxCommand ShowSelectedVacationCommand()
        {
            return new MvxCommand(() => ShowViewModel<SelectedVacationViewModel>(new { selectId = SelectedVocation.Id, aName = SelectedVocation.ApproverFullName }),() => SelectedVocation != null);
        }

        public ICommand _someCommand;
        public ICommand SomeCommand
        {
            get
            {
                return _someCommand ?? new MvxCommand<ShortVacationInfo>((value) =>
                {
                    ShowViewModel<SelectedVacationViewModel>(new { selectId = value.Id, aName = value.ApproverFullName });
                    //ShowSelectedVacation();
                });
            }
        }

        //Menu_________________________________________________________________________________________________________________

        private List<MenuViewModel> menuItems;
        public List<MenuViewModel> MenuItems
        {
            get { return this.menuItems; } 
            set { this.menuItems = value; this.RaisePropertyChanged(() => this.MenuItems); }
        }

        private MenuViewModel selectedItem;
        public MenuViewModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
                ExecuteSelectMenuItemCommand(selectedItem);
            }
        }


        private MvxCommand<MenuViewModel> m_SelectMenuItemCommand; 
         public ICommand SelectMenuItemCommand 
         { 
             get 
             { 
                 return this.m_SelectMenuItemCommand ?? (this.m_SelectMenuItemCommand = new MvxCommand<MenuViewModel>(this.ExecuteSelectMenuItemCommand)); 
             } 
         }

        private MvxCommand addCommand;
        public ICommand AddCommand
        {
            get { return this.addCommand ?? (this.addCommand = new MvxCommand(() => ShowViewModel<CreateVacationViewModel>())); }
        }
 
         private void ExecuteSelectMenuItemCommand(MenuViewModel item)
         { 
             //navigate if we have to, pass the id so we can grab from cache... or not 
             switch (item.Section) 
             { 
 

                 case Enums.MenuItems.AddVcation:
                     this.ShowViewModel<CreateVacationViewModel>();
                    //Close(this);
                     break; 
                 case Enums.MenuItems.SickToday: 
                     //this.ShowViewModel<>(new { item.Id });
                     break; 
                 case Enums.MenuItems.LogOn: 
                     this.ShowViewModel<AccountViewModel>(); 
                     break;
                case Enums.MenuItems.Vacations:
                    this.ShowViewModel<VacationsViewModel>();
                    break; 
             } 
         } 
    }
}
