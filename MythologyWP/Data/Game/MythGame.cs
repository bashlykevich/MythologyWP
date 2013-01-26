using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using MythologyWP.Data.DAO;
using MythologyWP.Data.DAL;
using System.Linq;
using MythologyWP.Helpers;

namespace MythologyWP.Data.Game
{
    public class MythGame
    {
        private List<Character> characters = new List<Character>();
        public int timeLeft;        
        public int aRight;
        public int aWrong;
        private int currentIndex;

        public string Status        
        {
            get
            {
                return aRight + "/" + currentIndex + "/" + characters.Count;
            }
        }
        public MythGame(int _timeLeft = 59)
        {
            currentIndex = 0;
            aRight = 0;
            aWrong = 0;
            timeLeft = _timeLeft;            
            // get all characters with nations filter
            characters = (from fd in MythDB.Instance.Database.Characters where fd.Nation.IsActive select fd).ToList();
            characters.Shuffle();            
        }
        public bool IsEndOfGame
        {
            get
            {
                if (currentIndex >= characters.Count)
                    return true;
                else
                    return false;
            }
        }
        public GameScreen NextRound()
        {
            //currentIndex++;
            if ((currentIndex < 0) || (currentIndex >= characters.Count) || (characters.Count == 0))
                throw new Exception("Index is out of range exception");
            return new GameScreen(characters[currentIndex++]);
        }
    }
}
