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

namespace MythologyWP.Data.Game
{
    public class MythGame
    {
        private List<Character> characters;
        private int totalTime = 60;
        private int[] nationsFilter = {-1};
        private int aRight = 0;
        private int aWrong = 0;        
    }
}
