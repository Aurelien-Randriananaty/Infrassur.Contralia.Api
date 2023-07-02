namespace Entities.Exceptions
{
    public class CheckAppOfflineStatusException : BadRequestException
	{
		public CheckAppOfflineStatusException() : base("API is not accessible, app is offline")
		{
		}
	}
}
