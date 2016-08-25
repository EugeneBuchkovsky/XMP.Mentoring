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
        }

        public override async void Start()
        {

            VocationList = await vocationsService.GetAllVocations();
            base.Start();
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

        public ICommand ShowSelectedVacationCommand()
        {
            return new MvxCommand(() => ShowViewModel<SelectedVacationViewModel>(new { selectId = SelectedVocation.Id, aName = SelectedVocation.ApproverFullName }),() => SelectedVocation != null);
        }
    }
}
