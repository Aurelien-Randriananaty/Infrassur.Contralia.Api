using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
	public class CheckAppOfflineStatusException : BadRequestException
	{
		public CheckAppOfflineStatusException() : base("API is not accessible, app is offline")
		{
		}
	}
}
