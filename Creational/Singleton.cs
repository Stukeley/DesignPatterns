namespace DesignPatterns.Creational.Singleton
{
	// A class of which only a single instance can exist
	public class Singleton
	{
		// This is the unique instance - only one exists at a time
		private static Singleton _instance;

		// The following property makes sure only one instance exists
		public static Singleton Instance
		{
			get
			{
				// If the instance is null (the property is called for the first time) - create a new one
				if (_instance is null)
				{
					_instance = new Singleton();
				}

				// Return the instance
				return _instance;
			}
		}

		public Singleton()
		{
		}
	}
}
