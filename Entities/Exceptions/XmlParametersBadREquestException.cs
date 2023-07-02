namespace Entities.Exceptions
{
    public class XmlParametersBadREquestException : BadRequestException
    {
        public XmlParametersBadREquestException() : base("Parameter xml is null")
        {
        }
    }
}
