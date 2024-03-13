using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUCA.Domain.Exceptions;
public class InnerException : Exception
{
	public InnerException(string message, int code) : base($"Message: {message} Code:{code}")
	{
	}
}
