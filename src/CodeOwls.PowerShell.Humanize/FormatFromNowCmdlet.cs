using System;
using System.Linq;
using System.Management.Automation;
using Humanizer;

namespace CodeOwls.PowerShell.Humanize
{
    [OutputType( typeof(string))]
    [Cmdlet(VerbsCommon.Format, "FromNow", ConfirmImpact = ConfirmImpact.Low)]
    public class FormatFromNowCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public DateTime[] InputObject { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject(InputObject.ToList().ConvertAll(s => s.Humanize( s.Kind == DateTimeKind.Utc )));
        }
    }
}