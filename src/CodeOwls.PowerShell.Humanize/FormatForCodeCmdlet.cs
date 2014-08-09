using System.Linq;
using System.Management.Automation;
using Humanizer;

namespace CodeOwls.PowerShell.Humanize
{
    [OutputType(typeof(string))]
    [Cmdlet(VerbsCommon.Format, "ForCode", ConfirmImpact = ConfirmImpact.Low)]
    public class FormatForCodeCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public string[] InputObject { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject( InputObject.ToList().ConvertAll( s=> s.Dehumanize() ));    
        }
    }
}