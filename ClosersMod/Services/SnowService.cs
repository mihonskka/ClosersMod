using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Services
{
    public class SnowService
    {
        /// <summary>
        /// 当前机器id
        /// </summary>
        long workerId=1;//当前机器id
        /// <summary>
        /// 唯一时间
        /// </summary>
        long twepoch;
        /// <summary>
        /// 序列
        /// </summary>
        long sequence;
        /// <summary>
        /// 机器码字节数
        /// </summary>
        int workerIdBits;
        /// <summary>
        /// 最大机器ID
        /// </summary>
        long maxWorkerId;
        /// <summary>
        /// 计数器字节数
        /// </summary>
        int sequenceBits;
        /// <summary>
        /// 机器码数据左移位数，也就是后面计数器占用的位数。
        /// </summary>
        int workerIdShift;
        /// <summary>
        /// 时间戳左移位数，就是机器码和计数器的总字节数。
        /// </summary>
        int timestampLeftShift;
        /// <summary>
        /// 一微秒内可以产生计数，如果达到该值则等到下一微秒再生成
        /// </summary>
        long sequenceMask;
        /// <summary>
        /// 
        /// </summary>
        long lastTimestamp;
        /// <summary>
        /// 
        /// </summary>
        object lockObj;

        public static SnowService instance = new SnowService((long)23333);

        public SnowService()
        {
            twepoch = TimeSpan.MinValue.Ticks;
            sequence = 0;
            workerIdBits = 4;
            maxWorkerId = -1 ^ -1 << workerIdBits;
            sequenceBits = 10;
            workerIdShift = sequenceBits;
            timestampLeftShift = sequenceBits + workerIdBits;
            sequenceMask = -1 ^ -1 << sequenceBits;
            lastTimestamp = -1;
            lockObj = new object();
        }

        public SnowService(long workerId) : this()
        {
            this.workerId = workerId;
        }

        public long nextId()
        {
            lock (lockObj)
            {
                long timestamp = timeGen();
                if (lastTimestamp == timestamp)
                {
                    sequence = sequence + 1 & sequenceMask;//利用&运算计算一微秒内产生的计数是否已经达到上限。
                    if (sequence == 0)
                        timestamp = tillNextMillis(lastTimestamp);//一微秒内产生的id计数已达到上限，等待下一微秒。
                }
                else sequence = 0;//不同微秒生成id，计数清零。
                if (timestamp < lastTimestamp)//如果当前时间戳比上一次生成id时的时间戳还要小，那么抛出异常，因为不能保证现在生成的id在之前没有被生成过。
                    throw new Exception($"警告，检测到时间倒流现象，雪花算法服务将在{lastTimestamp - timestamp}毫秒内拒绝生成id");
                lastTimestamp=timestamp;//把当前时间戳保存为最后生成id的时间戳
                long rv = (timestamp - twepoch << timestampLeftShift) | workerId << workerIdShift | sequence;
                return rv;
            }
        }
        public long nextIdnoLock()
        {
            long timestamp = timeGen();
            if (lastTimestamp == timestamp)
            {
                sequence = sequence + 1 & sequenceMask;//利用&运算计算一微秒内产生的计数是否已经达到上限。
                if (sequence == 0)
                    timestamp = tillNextMillis(lastTimestamp);//一微秒内产生的id计数已达到上限，等待下一微秒。
            }
            else sequence = 0;//不同微秒生成id，计数清零。
            if (timestamp < lastTimestamp)//如果当前时间戳比上一次生成id时的时间戳还要小，那么抛出异常，因为不能保证现在生成的id在之前没有被生成过。
                throw new Exception($"警告，检测到时间倒流现象，雪花算法服务将在{lastTimestamp - timestamp}毫秒内拒绝生成id");
            lastTimestamp = timestamp;//把当前时间戳保存为最后生成id的时间戳
            long rv = (timestamp - twepoch << timestampLeftShift) | workerId << workerIdShift | sequence;
            return rv;
        }
        
        long tillNextMillis(long lastTimestamp)
        {
            long timestamp = timeGen();
            while(timestamp <= lastTimestamp) timestamp = timeGen();
            return timestamp;
        }
        /// <summary>
        /// 生成当前时间戳
        /// </summary>
        /// <returns></returns>
        long timeGen() =>(long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
    }
}
