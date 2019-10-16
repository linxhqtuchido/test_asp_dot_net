using MySql.Data.MySqlClient;    
using System;    
using System.Collections.Generic;    
    
namespace mvcMembers.Models    
{    
    public class MemberDBContext    
    {    
        public string ConnectionString { get; set; }    
    
        public MemberDBContext(string connectionString)    
        {    
            this.ConnectionString = connectionString;    
        }    
    
        private MySqlConnection GetConnection()    
        {    
            return new MySqlConnection(ConnectionString);    
        }

        public List<Member> GetAllMember() {  
            List<Member> list = new List<Member>();  
        
            using (MySqlConnection conn = GetConnection())  
            {  
                conn.Open();  
                // MySqlCommand cmd = new MySqlCommand("select * from member where id < 10", conn);
                MySqlCommand cmd = new MySqlCommand("select * from member.member", conn);
        
                using (var reader = cmd.ExecuteReader())  
                {  
                    while (reader.Read())  
                    {  
                        list.Add(new Member()  
                        {  
                            Id = Convert.ToInt32(reader["Id"]),  
                            FirstName = reader["FirstName"].ToString(),  
                            SureName = reader["SureName"].ToString(),
                            Email = reader["Email"].ToString()  
                        });  
                    }  
                }  
            }  
            return list;  
        }

        public List<Member> SearchMember(string SureName, string Email) {  
            List<Member> list = new List<Member>();  
        
            using (MySqlConnection conn = GetConnection())  
            {  
                conn.Open();
                string where = "";
                if(SureName != "") {
                    where = "Surename LIKE  '"+SureName+"%'";
                }
                if(Email != "") {
                    where = "Email LIKE '"+Email+"%'";
                }
                if(SureName != "" && Email != "") {
                    where = "Surename LIKE '"+SureName+"%' and Email LIKE '"+Email+"%'";
                }
                MySqlCommand cmd = new MySqlCommand("select * from member.member where "+where+" ", conn);
        
                using (var reader = cmd.ExecuteReader())  
                {  
                    while (reader.Read())  
                    {  
                        list.Add(new Member()  
                        {  
                            Id = Convert.ToInt32(reader["Id"]),  
                            FirstName = reader["FirstName"].ToString(),  
                            SureName = reader["SureName"].ToString(),
                            Email = reader["Email"].ToString()  
                        });  
                    }  
                }  
            }  
            return list;  
        }

        public void AddMember(string FirstName, string SureName, string Email) {
            using (MySqlConnection conn = GetConnection())  
            {
                MySqlCommand result = new MySqlCommand("Insert into member.member (FirstName,SureName,Email ) values('" +FirstName.ToString()+ "','" +SureName.ToString()+ "','" +Email.ToString()+ "');", conn);
                MySqlDataReader MyReader2;  
                conn.Open();  
                MyReader2 = result.ExecuteReader();
                while (MyReader2.Read()){                     
                    
                }  
                conn.Close();
            }
        }

        public void UpdateInlineMember(int Id, string FirstName, string SureName, string Email) {
            using (MySqlConnection conn = GetConnection())  
            {
                // MySqlCommand result = new MySqlCommand("Insert into member.member (FirstName,SureName,Email ) values('" +FirstName.ToString()+ "','" +SureName.ToString()+ "','" +Email.ToString()+ "');", conn);
                MySqlCommand result = new MySqlCommand("UPDATE member.member SET FirstName = '" +FirstName.ToString()+ "', SureName = '" +SureName.ToString()+ "', Email ='" +Email.ToString()+ "' WHERE Id = '"+Id+"';", conn);
                MySqlDataReader MyReader2;  
                conn.Open();  
                MyReader2 = result.ExecuteReader();
                while (MyReader2.Read()){                     
                    
                }  
                conn.Close();
            }
        }
    }
}