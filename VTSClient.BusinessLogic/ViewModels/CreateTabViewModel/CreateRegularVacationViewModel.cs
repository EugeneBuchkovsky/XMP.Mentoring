using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VTSClient.BusinessLogic.Converters;
using VTSClient.BusinessLogic.Services.Interfaces;
using VTSClient.DataAccess.Repositories;
using VtsMockClient.Domain.Enums;
using MvvmCross.Plugins.PictureChooser;
using VtsMockClient.Domain.Models;
using System.IO;

namespace VTSClient.BusinessLogic.ViewModels.CreateTabViewModel
{
    public class CreateRegularVacationViewModel : CreateViewModel
    {
        private IVacationsService service;
        private IRepository repo;
        private IMvxPictureChooserTask pictureChooser;

        public CreateRegularVacationViewModel(IVacationsService vs, IRepository repo, IMvxPictureChooserTask chooser)
        {
            this.service = vs;
            this.repo = repo;
            this.pictureChooser = chooser;

            ApproverList = service.GetApproversSync();
        }

        //public override void Start()
        //{
        //    //ApproverList = await service.GetApprovers();
        //    base.Start();
        //}


        private Person selectedApprover;
        public Person SelectedApprover
        {
            get { return selectedApprover; }
            set
            {
                selectedApprover = value;
                RaisePropertyChanged(() => SelectedApprover);
            }
        }

        public ICommand _someCommand;
        public ICommand SomeCommand
        {
            get
            {
                return _someCommand ?? new MvxCommand<Person>((value) =>
                {
                    selectedApprover = value;
                    //ShowSelectedVacation();
                });
            }
        }

        //public IMvxCommand ShowSelectedApproverCommand()
        //{
        //    return new MvxCommand(() => );
        //}

        public override async void SaveChanges()
        {
            var start = MyStringToDateConverter.Convert(StartD);
            var end = MyStringToDateConverter.Convert(EndD);
            if (SelectedApprover == null)
                SelectedApprover = ApproverList.First();

            if (DateCheck(start, end))
            {
                var model = new VacationInfo
                {
                    ApproverId = SelectedApprover.Id,
                    EmployeeId = repo.GetCurrentUser().Id,
                    NoProjectManagerObjections = true,
                    Comment = this.Comment,
                    //StartDate = this.StartDate,
                    StartDate = start,
                    EndDate = end.AddHours(8),
                    Status = VacationStatus.Waiting,
                    Type = VacationType.Regular
                };

                var a = MyStringToDateConverter.Convert(StartD);

                await service.UpdateVacationInfo(model);
                ShowViewModel<VacationsViewModel>();
            }
            else
                Message = "Invalid dates!";
            //Close(this);
        }

        //add picture

        private MvxCommand addPicture;
        public ICommand AddPicture
        {
            get
            {
                addPicture = addPicture ?? new MvxCommand(DoPicture);
                return addPicture;
            }
        }

        private void DoPicture()
        {
            pictureChooser.ChoosePictureFromLibrary(400, 95, OnPicture, () => { });
        }

        private void OnPicture(Stream stream)
        {
            var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            PictureBytes = memoryStream.ToArray();
        }

        private byte[] _pictureBytes;
        public byte[] PictureBytes
        {
            get { return _pictureBytes; }
            set { _pictureBytes = value; RaisePropertyChanged(() => PictureBytes); }
        }

        //___________
    }
}
