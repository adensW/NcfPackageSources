using System;

namespace Senparc.Xncf.PromptRange.OHS.Local.PL.Response
{
    public class BaseResponse
    {
        public int Id { get; set; }

        // public DateTime CreateTime { get; set; }

        public DateTime LastRunTime { get; set; } = DateTime.Now;
    }
}