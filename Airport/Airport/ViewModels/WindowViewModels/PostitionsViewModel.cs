using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Airport.ViewModels.WindowViewModels
{
    public class PositionsViewModel
    {
        public ObservableCollection<Position> Positions { get; set; }
        private PositionService _positionService;
        private WorkerService _workerService;
        private readonly IWindowService _windowService;
        
        public ICommand OpenEditWindowCommand { get; }
        public ICommand DeleteElmentCommand { get; }

        public PositionsViewModel()
        {
            _positionService = new PositionService();
            LoadPositions();
            _windowService = new WindowService();
            _workerService = new WorkerService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            DeleteElmentCommand = new RelayCommand(OnDelete);
        }
     
        private void OnEdit(object parameter)
        {

            var position = parameter as Position;
            if (position != null)
            {
                _windowService.OpenWindow("ChangePosition", position);
                _windowService.CloseWindow();

            }
        }






        private void OnDelete(object parameter)
        {



            var position = parameter as Position;
            if (position != null)
            {
                List<Worker> workerList = _workerService.GetWorkerDataByPositionId(position.PositionId);
                if (workerList.Count == 0)
                {
                    MessageBoxResult result = MessageBox.Show(
                      "Якщо ви натисните так, cтруктурну одиницю назавжди буде видалено з бази!",
                      "Ви дійсно хочете видалити cтруктурну одиницю?",

                     MessageBoxButton.YesNo,
                     MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {

                        Positions.Remove(position);
                        _positionService.DeletePostion(position.PositionId);

                        MessageBox.Show("Стуркутрну одиницю успішно видалено", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                else
                {
                    MessageBox.Show("В базі наявні посади , що підпорядковуються даному департаменту! Видаліть, посади даної структурної одиниці, для виконання операції видалення!", "Помилка видалення департаменту",
                     MessageBoxButton.OK,
                     MessageBoxImage.Error);
                }
            }





        }


        private void LoadPositions()
        {
            try
            {
                var positionList = _positionService.GetPositionsData();
                Positions = new ObservableCollection<Position>(positionList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
