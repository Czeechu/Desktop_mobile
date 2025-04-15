using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ToDoClassLibrary;
using ToDoClassLibrary.Models;
using Microsoft.Maui.Controls;

namespace ToDoListMauiApp.ViewModels
{
    public class MainPageViewModel : BindableObject
    {

        private TaskRepository taskRepository = new TaskRepository();

        private string taskContent;
        public string TaskContent
        {
            get { return taskContent; }
            set { taskContent = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Todotask> activeTasks;
        public ObservableCollection<Todotask> ActiveTasks
        {
            get { return activeTasks; }
            set { activeTasks = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Todotask> deletedTasks;
        public ObservableCollection<Todotask> DeletedTasks
        {
            get { return deletedTasks; }
            set { deletedTasks = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Todotask> doneTasks;
        public ObservableCollection<Todotask> DoneTasks
        {
            get { return doneTasks; }
            set { doneTasks = value; OnPropertyChanged(); }
        }


        private Command addTaskCommand;
        public Command AddTaskCommand
        {
            get
            {
                if (addTaskCommand == null)
                {
                    addTaskCommand = new Command(() =>
                    {
                        if (!string.IsNullOrEmpty(TaskContent))
                        {
                            taskRepository.CreateNewTask(TaskContent);
                            LoadTasks();
                        }
                    });
                }
                return addTaskCommand;
            }
        }
        private Command loadTasksCommand;
        public Command LoadTasksCommand
        {
            get
            {
                if (loadTasksCommand == null)
                {
                    loadTasksCommand = new Command(LoadTasks);
                }
                return loadTasksCommand;
            }
        }
        private Command markTaskAsDeletedCommand;
        public Command MarkTaskAsDeletedCommand
        {
            get
            {
                if (markTaskAsDeletedCommand == null)
                {
                    markTaskAsDeletedCommand = new Command <Todotask>((task) =>
                    {
                        if (task != null)
                        {
                            taskRepository.MarkTaskAsDeleted(task.Id);
                            LoadTasks();
                        }
                    });
                }
                return markTaskAsDeletedCommand;
            }
        }

        private Command doneCommand;
        public Command DoneCommand
        {
            get
            {
                if (doneCommand == null)
                {
                    doneCommand = new Command<Todotask>((task) =>
                    {
                        if (task != null)
                        {
                            taskRepository.SaveChanges(task);
                            LoadTasks();
                        }
                    });
                }
                return doneCommand;
            }
        }

        public MainPageViewModel()

        {
            ActiveTasks = new ObservableCollection<Todotask>();
            DeletedTasks = new ObservableCollection<Todotask>();

            LoadTasks();
        }

        public void LoadTasks()
        {
            var active = taskRepository.GetActiveTasks();
            ActiveTasks.Clear();
            foreach (var task in active)
            {
                ActiveTasks.Add(task);
            }

            var deleted = taskRepository.GetDeletedTasks();
            DeletedTasks.Clear();
            foreach (var task in deleted)
            {
                DeletedTasks.Add(task);
            }
        }
    }
}