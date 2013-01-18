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
        //private int[] nationsFilter = {-1};
        private int aRight;
        private int aWrong;
        private int currentIndex;

        public MythGame(int _timeLeft = 59 /* ,int[] _nationsFilter = null*/)
        {
            currentIndex = 0;
            aRight = 0;
            aWrong = 0;
            timeLeft = _timeLeft;
            /*if (_nationsFilter != null)
                nationsFilter = _nationsFilter;*/
            // get all characters
            characters = (from fd in MythDB.Instance.Database.Characters select fd).ToList();
            characters.Shuffle();            
        }
        public bool IsEndOfGame()
        {
            if (currentIndex >= characters.Count)
                return true;
            else
                return false;
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
