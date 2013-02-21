namespace WindowsService
{
	using System.ServiceProcess;
	using Service;

	public partial class SuperUberService : ServiceBase
	{
		private Monitor _monitor;

		public SuperUberService()
		{
			this.InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			this._monitor = new Monitor("c:\\foobar", "*.dll");
			this._monitor.Start();
		}

		protected override void OnStop()
		{
			this._monitor.Stop();
		}

		protected override void OnPause()
		{
			this._monitor.Pause();
		}

		protected override void OnContinue()
		{
			this._monitor.Continue();
		}

		protected override void OnShutdown()
		{
			this._monitor.Dispose();
		}
	}
}