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

        private Todotask currentTask;
        public Todotask CurrentTask
        {
            get { return currentTask; }
            set { currentTask = value; OnPropertyChanged(); }
        }

        public Command AddTaskCommand;
        public Command LoadTasksCommand;
        public Command MarkTaskAsDeletedCommand;
        public Command SaveChangesCommand;

        public MainPageViewModel()
        {
            ActiveTasks = new ObservableCollection<Todotask>();
            DeletedTasks = new ObservableCollection<Todotask>();

            AddTaskCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TaskContent))
                {
                    taskRepository.CreateNewTask(TaskContent);
                    LoadTasks();
                }
            });

            LoadTasksCommand = new Command(LoadTasks);

            MarkTaskAsDeletedCommand = new Command(() =>
            {
                if (CurrentTask != null)
                {
                    taskRepository.MarkTaskAsDeleted(CurrentTask.Id);
                    LoadTasks();
                }
            });

            SaveChangesCommand = new Command(() =>
            {
                if (CurrentTask != null)
                {
                    taskRepository.SaveChanges(CurrentTask);
                    LoadTasks();
                }
            });

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
