using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace testAsp.Pages.Posts
{
    public class IndexModel : PageModel
    {
        public List<Post> ListPosts = new List<Post>();
        //B@exam.com
        //Aa_123
        public IndexModel()
        {
            Get();
        }

        public void Get()
        {
            List<Post> ListPosts = new List<Post>();
            try
            {
                String connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=asp_exam;Integrated Security=True";

                using (SqlConnection connetion = new SqlConnection(connectionString))
                {
                    connetion.Open();
                    String sql = "SELECT [posts].[post_id], [posts].[image], [posts].[title], [posts].[description], [posts].[user_id], [AspNetUsers].[UserName] FROM [dbo].[posts] JOIN [dbo].[AspNetUsers] ON [dbo].[posts].user_id = [dbo].[AspNetUsers].[Id]; ";
                    using (SqlCommand cmd = new SqlCommand(sql, connetion))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Post post = new Post();
                                if (!reader.IsDBNull(0))
                                    post.post_id = reader.GetInt32(0);
                                if (!reader.IsDBNull(1))
                                {
                                    using SqlDataAdapter da = new SqlDataAdapter(cmd);
                                    using DataSet ds = new DataSet();
                                    da.Fill(ds);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {

                                        using MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Image"]);
                                        //post.image = new Bitmap(ms);
                                        post.image = new Bitmap(ms);
                                    }
                                }
                                if (!reader.IsDBNull(2))
                                    post.title = reader.GetString(2);
                                if (!reader.IsDBNull(3))
                                    post.description = reader.GetString(3);
                                if (!reader.IsDBNull(4))
                                    post.user_id = reader.GetString(4);
                                if (!reader.IsDBNull(5))
                                    post.userName = reader.GetString(5);

                                ListPosts.Add(post);
                            }
                        }
                    }
                }
                this.ListPosts = ListPosts;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("sql Error");
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
    public class Post
    {
        public int post_id { get; set; }
        public string user_id { get; set; }
        public Image image { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string userName { get; set; }
    }
}
