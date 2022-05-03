using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MyLaptopShop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace MyLaptopShop.WpfClient.ViewModels
{
    public class SpecificationWindowViewModel : ObservableRecipient
    {
        public RestCollection<Specification> Specifications { get; set; }

        private Specification selectedSpecification;

        public Specification SelectedSpecification
        {
            get => selectedSpecification; set
            {
                if (value != null)
                {
                    selectedSpecification = new Specification()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        LaptopId = value.LaptopId,
                        CPU = value.CPU,
                        GraphicsCardName = value.GraphicsCardName,
                        RAM = value.RAM,
                        AdditionalPrice = value.AdditionalPrice,
                    };
                    OnPropertyChanged();
                    (DeleteSpecificationCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateSpecificationCommand { get; set; }
        public ICommand UpdateSpecificationCommand { get; set; }
        public ICommand DeleteSpecificationCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public SpecificationWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Specifications = new RestCollection<Specification>("http://localhost:60327/", "brand", "hub");
                CreateSpecificationCommand = new RelayCommand(() =>
                {
                    Specifications.Add(new Specification()
                    {
                        Name = SelectedSpecification.Name,
                        LaptopId= SelectedSpecification.LaptopId,
                        CPU= SelectedSpecification.CPU,
                        GraphicsCardName= SelectedSpecification.GraphicsCardName,
                        RAM= SelectedSpecification.RAM,
                        AdditionalPrice= SelectedSpecification.AdditionalPrice,
                    });
                });

                DeleteSpecificationCommand = new RelayCommand(() =>
                {
                    Specifications.Delete(SelectedSpecification.Id);
                },
                () =>
                {
                    return SelectedSpecification != null;
                });

                UpdateSpecificationCommand = new RelayCommand(() =>
                {
                    Specifications.Update(SelectedSpecification);
                });
                selectedSpecification = new Specification();
            }
        }
    }
}
