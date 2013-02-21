namespace WindowsService.Service
{
	using System;
	using System.IO;

	public class Monitor : IDisposable
	{
		private FileSystemWatcher _fileSystemWatcher;

		public Monitor(string path, string filter)
		{
			this._fileSystemWatcher = new FileSystemWatcher();

			if (!Directory.Exists(path))
			{
				throw new DirectoryNotFoundException(string.Format("Directory not found: {0}", path));
			}

			this._fileSystemWatcher.Path = path;
			this._fileSystemWatcher.Filter = filter;

			this._fileSystemWatcher.Created += this.fileSystemWatcher_Created;
		}

		public void Start()
		{
			this._fileSystemWatcher.EnableRaisingEvents = true;
		}

		public void Stop()
		{
			this._fileSystemWatcher.EnableRaisingEvents = false;
		}

		private void fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
		{
			// do magic
		}

		public void Dispose()
		{
			this.Stop();

			this._fileSystemWatcher = null;
		}

		public void Pause()
		{
			this.Stop();
		}

		public void Continue()
		{
			this.Start();
		}
	}
}