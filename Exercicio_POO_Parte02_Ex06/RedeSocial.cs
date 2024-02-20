using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_POO_Parte02_Ex06
{
    internal class RedeSocial
    {
        public string Friends { get; set; }
        public string Messager { get; set; }   
        public string Posts { get; set; }
        public string Perfil { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        private List<string> friendList = new List<string>();


        public RedeSocial( string friends, string messager, string posts, string perfil,string email, string password ) 
        { 
            Friends = friends;
            Messager = messager;  
            Posts = posts;  
            Perfil = perfil;    
            Email = email;
            Password = password;
        }

        public string CreateUserAccount()
        {
            return "A conta foi criada com sucesso.";
        }
        public void AddFriends(string friendUsername)
        {
            if (!friendList.Contains(friendUsername))
            {
                friendList.Add(friendUsername);
                Console.WriteLine($"{friendUsername} adicionado à lista de amigos.");
            }
            else
            {
                Console.WriteLine($"{friendUsername} já está na lista de amigos.");
            }
        }
        public void RemoveFriends(string friendUsername)
        {
            if (friendList.Contains(friendUsername))
            {
                friendList.Remove(friendUsername);
                Console.WriteLine($"{friendUsername} removido da lista de amigos.");
            }
            else
            {
                Console.WriteLine($"{friendUsername} não está na lista de amigos.");
            }
        }
        public string SendMessages(string recipient, string message)
        {
            if (!string.IsNullOrEmpty(recipient) && !string.IsNullOrEmpty(message))
            {
                return "Message sent successfully.";
            }
            else
            {
                return "Failed to send message.";
            }
        }
        public string PostComment(int postId, string commentText)
        {
            if (postId > 0 && !string.IsNullOrEmpty(commentText))
            {
                return "Comment posted successfully.";
            }
            else
            {
                return "Failed to post comment.";
            }
        }
        public string SearchUsers(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                return "Users found.";
            }
            else
            {
                return "No users found.";
            }
        }
    }
}
