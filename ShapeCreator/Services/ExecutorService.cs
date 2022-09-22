using ShapeCreator.Adaptors;

namespace ShapeCreator.Services
{
    public class ExecutorService
    {
        private readonly IMainService _mainService;
        private readonly IConsoleAdaptor _consoleAdaptor;

        public ExecutorService(IMainService mainService, IConsoleAdaptor consoleAdaptor)
        {
            _mainService = mainService;
            _consoleAdaptor = consoleAdaptor;
        } 

        public void Start()
        {
            try
            {
                var outputType = _mainService.GetOutputType();
                var shape = _mainService.GetShape();

                _mainService.DrawShape(outputType, shape);
            }
            catch (Exception ex)
            {
                _consoleAdaptor.WriteLine(ex.Message);
            }
        }
    }
}
