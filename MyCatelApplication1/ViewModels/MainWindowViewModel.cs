namespace MyCatelApplication1.ViewModels
{
    using Catel;
    using Catel.Data;
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.Services;
    using MyCatelApplication1.Models;
    using MyCatelApplication1.Services.Interfaces;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public class MainWindowViewModel : ViewModelBase
    {


        private readonly IFamilyService _familyService;
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IMessageService _messageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel(IFamilyService familyService, IUIVisualizerService uiVisualizerService, IMessageService messageService)
        {
            Argument.IsNotNull(() => familyService);
            Argument.IsNotNull(() => uiVisualizerService);
            Argument.IsNotNull(() => messageService);

            _familyService = familyService;
            _uiVisualizerService = uiVisualizerService;
            _messageService = messageService;

            AddFamily = new TaskCommand(OnAddFamilyExecuteAsync);
            RemovePerson = new TaskCommand(OnRemovePersonExecuteAsync, OnRemovePersonCanExecute);
            EditPerson = new TaskCommand(OnEditPersonExecuteAsync, OnEditPersonCanExecute);
        }


        public TaskCommand AddFamily { get; private set; }

        /// <summary>
        /// Method to invoke when the AddFamily command is executed.
        /// </summary>
        private async Task OnAddFamilyExecuteAsync()
        {
            var family = new Family() { FamilyName = "Gustav" };
            // Note that we use the type factory here because it will automatically take care of any dependencies
            // that the FamilyWindowViewModel will add in the future
            var typeFactory = this.GetTypeFactory();
            var familyWindowViewModel = typeFactory.CreateInstanceWithParametersAndAutoCompletion<FamilyWindowViewModel>(family);
            if (await _uiVisualizerService.ShowDialogAsync(familyWindowViewModel) ?? false)
            {
                Families.Add(family);
            }
        }

        public override string Title { get { return "Welcome to MyCatelApplication1"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            var families = _familyService.LoadFamilies();
            Families = new ObservableCollection<Family>(families);

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }

        public ObservableCollection<Family> Families
        {
            get { return GetValue<ObservableCollection<Family>>(FamiliesProperty); }
            private set { SetValue(FamiliesProperty, value); }
        }

        /// <summary>
        /// Register the Families property so it is known in the class.
        /// </summary>
        public static readonly PropertyData FamiliesProperty = RegisterProperty("Families", typeof(ObservableCollection<Family>), null);

        public Family SelectedFamily
        {
            get { return GetValue<Family>(SelectedFamilyProperty); }
            set { SetValue(SelectedFamilyProperty, value); }
        }

        /// <summary>
        /// Register the SelectedFamily property so it is known in the class.
        /// </summary>
        public static readonly PropertyData SelectedFamilyProperty = RegisterProperty("SelectedFamily", typeof(Family), null);

        /// <summary>
        /// Gets the RemovePerson command.
        /// </summary>
        public TaskCommand RemovePerson { get; private set; }

        /// <summary>
        /// Method to check whether the RemovePerson command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnRemovePersonCanExecute()
        {
            return SelectedFamily != null;
        }

        /// <summary>
        /// Method to invoke when the RemovePerson command is executed.
        /// </summary>
        private async Task OnRemovePersonExecuteAsync()
        {
            if (await _messageService.ShowAsync(string.Format("Are you sure you want to delete the person '{0}'?", SelectedFamily),
                "Are you sure?", MessageButton.YesNo, MessageImage.Question) == MessageResult.Yes)
            {
                Families.Remove(SelectedFamily);
                SelectedFamily = null;
            }
        }

        /// <summary>
        /// Gets the EditPerson command.
        /// </summary>
        public TaskCommand EditPerson { get; private set; }

        /// <summary>
        /// Method to check whether the EditPerson command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnEditPersonCanExecute()
        {
            return SelectedFamily != null;
        }

        /// <summary>
        /// Method to invoke when the EditPerson command is executed.
        /// </summary>
        private async Task OnEditPersonExecuteAsync()
        {
            // Note that we use the type factory here because it will automatically take care of any dependencies
            // that the PersonViewModel will add in the future
            var typeFactory = this.GetTypeFactory();
            var personViewModel = typeFactory.CreateInstanceWithParametersAndAutoCompletion<FamilyWindowViewModel>(SelectedFamily);
            await _uiVisualizerService.ShowDialogAsync(personViewModel);
        }
    }
}
