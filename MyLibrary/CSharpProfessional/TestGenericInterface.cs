using System;

namespace CSharpProfessional
{
    public class TaskDescriptor
    {
        public string Name;
    }

    public class ATaskDescriptor : TaskDescriptor
    {
        public string NameA;
    }

    public interface ITaskRunner<T>
    {
        void Run(T t);
    }

    public abstract class TaskRunnerBase<T> : ITaskRunner<T>
    {
        public abstract void Run(T t);
    }

    public class ATaskRunner : TaskRunnerBase<ATaskDescriptor>
    {
        public override void Run(ATaskDescriptor t)
        {
            throw new NotImplementedException();
        }
    }

    public interface ITaskFactory<T>
    {
        ITaskRunner<T> CreateTaskRunner();
    }

    public class TaskFactory<T> : ITaskFactory<T>
    {
        public ITaskRunner<T> CreateTaskRunner()
        {
            //return new ATaskRunner<ATaskDescriptor>();
            throw new NotImplementedException();
        }
    }

    public class TestGenericInterface
    {
        //TaskFactory<TaskDescriptor> factory = new TaskFactory<TaskDescriptor>();

        //ITaskRunner<T> runner = factory.CreateTaskRunner();
        ITaskRunner<ATaskDescriptor> taskRunner = new ATaskRunner();
    }
}
