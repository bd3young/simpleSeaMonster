using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleMonsterClass
{
	public class SeaMonster
	{
		public enum EmotionalState
		{
			HAPPY,
			SAD,
			ANGRY,
		}

		#region FIELDS

		private string _name;
		private double _weight;
		private bool _canUseFreshWater;
		private EmotionalState _currentEmotionalState;
		private string _homeSea;
        private DateTime _birthDate;




        #endregion

        #region PROPERTIES

        public bool CanUseFreshWater
		{
			get { return _canUseFreshWater; }
			set { _canUseFreshWater = value; }
		}


		public double Weight
		{
			get { return _weight; }
			set { _weight = value; }
		}


		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public EmotionalState CurrentEmotionalState
		{
			get { return _currentEmotionalState; }
			set { _currentEmotionalState = value; }
		}

		public string HomeSea
		{
			get { return _homeSea; }
			set { _homeSea = value; }
		}

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

		#endregion

		#region Constructors

		public SeaMonster()
		{

		}

		public SeaMonster(string name)
		{
			_name = name;
		}

		#endregion

		#region Methods

		public string SeaMonsterAttitude()
		{
			return _name + " is " + _currentEmotionalState + ".";
		}

		#endregion
	}
}
