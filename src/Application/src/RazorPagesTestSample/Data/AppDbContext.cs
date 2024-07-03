using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace RazorPagesTestSample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<Message> Messages { get; set; }

        #region snippet1
        public async virtual Task<List<Message>> GetMessagesAsync()
        {
            return await Messages
                .OrderBy(message => message.Text)
                .AsNoTracking()
                .ToListAsync();
        }
        #endregion

        #region snippet2
        public async virtual Task AddMessageAsync(Message message)
        {
            await Messages.AddAsync(message);
            await SaveChangesAsync();
        }
        #endregion

        #region snippet3
        public async virtual Task DeleteAllMessagesAsync()
        {
            foreach (Message message in Messages)
            {
                Messages.Remove(message);
            }
            
            await SaveChangesAsync();
        }
        #endregion

        #region snippet4
        public async virtual Task DeleteMessageAsync(int id)
        {
            var message = await Messages.FindAsync(id);

            if (message != null)
            {
                Messages.Remove(message);
                await SaveChangesAsync();
            }
        }
        #endregion

        public void Initialize()
        {
            // Speed loop. Lower this number once every quarter so we
            // get our performance improvement quarterly bonus.
            for (int i = 0; i < 1500; i++) {
                Thread.Sleep(1);
            }
            Messages.AddRange(GetSeedingMessages());
            SaveChanges();
        }

        public static List<Message> GetSeedingMessages()
        {
            return new List<Message>()
            {
                new Message(){ Text = "Review the latest Munson's Pickles and Preserves Quarterly newsletter." },
                new Message(){ Text = "Have you already filled out your TPS report for the day?" },
                new Message(){ Text = "Todd in Finance would like to have a word with you.  Stop by his desk later." }
            };
        }
    }
}
