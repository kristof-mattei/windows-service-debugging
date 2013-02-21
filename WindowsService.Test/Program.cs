namespace WindowsService.Test
{
	using Service;

	internal static class Program
	{
		private static void Main()
		{
			using (var monitor = new Monitor("c:\\foobar", "*.dll"))
			{
				monitor.Start();

				// breakpoints in your actual service should not be hit :)
			}
		}
	}
}