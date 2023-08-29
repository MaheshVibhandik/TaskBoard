using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaskBoard.Models;
using TaskBoard.Repository;
using TaskBoard.Repository.Repos;
using TaskBoard.TestData;

namespace TaskBoard.Services.Tests
{
    [TestClass()]
    public class TaskServiceTests
    {
        private Mock<IUnitOfWork>? _mockUnitOfWork;
        private Mock<ITaskRepository>? _mockTaskRepository;

        [TestInitialize]
        public void Initialize()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockTaskRepository = new Mock<ITaskRepository>();
        }

        #region Create Task Test
        [TestMethod()]
        public void CreateTaskTest_ShouldSucess()
        {
            //Arrange        

            int _expectedRowsAffetcted = 1;
            _mockUnitOfWork.Setup(x => x.Save()).Returns(_expectedRowsAffetcted);
            _mockUnitOfWork.SetupGet(x => x.Tasks).Returns(_mockTaskRepository.Object);

            var taskService = new TaskService(_mockUnitOfWork.Object);
            var taskJob = TaskData.GetTheTaskJobData(101);

            //Act
            bool istaskCreated = taskService.CreateTask(taskJob).Result;

            //Assert
            Assert.AreEqual(true, istaskCreated);
        }

        [TestMethod()]
        public void CreateTaskTest_ShouldFails_OnceTaskNotAdded_InRepository()
        {
            //Arrange        

            int _expectedRowsAffetcted = 0;
            _mockUnitOfWork.Setup(x => x.Save()).Returns(_expectedRowsAffetcted);
            _mockUnitOfWork.SetupGet(x => x.Tasks).Returns(_mockTaskRepository.Object);

            var taskService = new TaskService(_mockUnitOfWork.Object);
            var taskJob = TaskData.GetTheTaskJobData(101);

            //Act
            bool istaskCreated = taskService.CreateTask(taskJob).Result;

            //Assert
            Assert.AreEqual(false, istaskCreated);
        }

        [TestMethod()]
        public void CreateTaskTest_WithNullTask_ShouldFails()
        {
            //Arrange
            int _expectedRowsAffetcted = 1;
            _mockUnitOfWork.Setup(x => x.Save()).Returns(_expectedRowsAffetcted);

            var taskService = new TaskService(_mockUnitOfWork.Object);
            var taskJob = TaskData.GetTheTaskJobData(101);

            //Act
            bool istaskCreated = taskService.CreateTask(null).Result;

            //Assert
            Assert.AreEqual(false, istaskCreated);
        }
        #endregion

        #region Delete Task Test
        [TestMethod()]
        public void DeleteTaskTest_ShouldSucess()
        {
            //Arrange        
            var taskJob = TaskData.GetTheTaskJobData(101);

            int _expectedRowsAffetcted = 1;
            _mockTaskRepository.Setup(x => x.Delete(It.IsAny<TaskJob>()));
            _mockTaskRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(taskJob));

            _mockUnitOfWork.Setup(x => x.Save()).Returns(_expectedRowsAffetcted);
            _mockUnitOfWork.SetupGet(x => x.Tasks).Returns(_mockTaskRepository.Object);

            var taskService = new TaskService(_mockUnitOfWork.Object);

            //Act
            bool istaskCreated = taskService.CreateTask(taskJob).Result;

            //Assert
            Assert.AreEqual(true, istaskCreated);


            //Act
            bool isTaskdeleted = taskService.DeleteTask(taskJob.Id).Result;

            //Assert
            Assert.AreEqual(true, isTaskdeleted);
        }

        [TestMethod()]
        public void DeleteTaskTest_ShouldFails_OnceTaskNotDeleted_FromRepository()
        {
            //Arrange        
            var taskJob = TaskData.GetTheTaskJobData(101);
            _mockTaskRepository.Setup(x => x.Delete(It.IsAny<TaskJob>()));
            _mockTaskRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(taskJob));

            int _expectedRowsAffetcted = 1;
            _mockUnitOfWork.Setup(x => x.Save()).Returns(_expectedRowsAffetcted);
            _mockUnitOfWork.SetupGet(x => x.Tasks).Returns(_mockTaskRepository.Object);

            var taskService = new TaskService(_mockUnitOfWork.Object);

            //Act
            bool istaskCreated = taskService.CreateTask(taskJob).Result;

            //Assert
            Assert.AreEqual(true, istaskCreated);

            //Arrange
            _expectedRowsAffetcted = 0;
            _mockUnitOfWork.Setup(x => x.Save()).Returns(_expectedRowsAffetcted);

            //Act
            bool isTaskdeleted = taskService.DeleteTask(taskJob.Id).Result;

            //Assert
            Assert.AreEqual(false, isTaskdeleted);
        }

        [TestMethod()]
        public void DeleteTaskTest_WithNullTask_ShouldFails()
        {
            //Arrange
            int _expectedRowsAffetcted = 1;
            _mockUnitOfWork.Setup(x => x.Save()).Returns(_expectedRowsAffetcted);

            var taskService = new TaskService(_mockUnitOfWork.Object);
            var taskJob = TaskData.GetTheTaskJobData(101);

            //Act
            bool istaskCreated = taskService.CreateTask(null).Result;

            //Assert
            Assert.AreEqual(false, istaskCreated);
        }
        #endregion

        #region GetAll Task Test
        [TestMethod()]
        public void GetAllTaskTest_ShouldSucess()
        {

            //Arrange        
            var expectedTaskCount = 5;
            var taskList = TaskData.GetTaskJobList(expectedTaskCount).ToList();

            int _expectedRowsAffetcted = 1;
            _mockTaskRepository.Setup(x => x.Delete(It.IsAny<TaskJob>()));
            _mockTaskRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(taskList[0]));
            _mockTaskRepository.Setup(x => x.GetAll()).Returns(Task.FromResult(taskList.AsEnumerable()));

            _mockUnitOfWork.Setup(x => x.Save()).Returns(_expectedRowsAffetcted);
            _mockUnitOfWork.SetupGet(x => x.Tasks).Returns(_mockTaskRepository.Object);

            var taskService = new TaskService(_mockUnitOfWork.Object);

            //Act
            bool istaskCreated = taskService.CreateTask(taskList[0]).Result;
            istaskCreated = taskService.CreateTask(taskList[1]).Result;

            //Assert
            Assert.AreEqual(true, istaskCreated);

            //Act
            var tasks = taskService.GetAllTask().Result;

            //Assert
            Assert.IsNotNull(tasks);
            Assert.AreEqual(expectedTaskCount,tasks.Count());
        }
        #endregion        
    }
}