namespace PMS_Entity.Model.Master.Test
{
    using System;

    public partial class Test_Depth_Of_Inheritance
    {
        public Test_Depth_Of_Inheritance()
        {

        }

        public string getDate()
        {
            return "Test_Depth_Of_Inheritance";
        }

        public string getTest()
        {
            return "Test_Depth_Of_Inheritance";
        }

    }


    public partial class Test_Depth_Of_Inheritance2 : Test_Depth_Of_Inheritance
    {
        public string name = "";
        public string getDate2()
        {
            string _message = "";
            try
            {
                _message = "Test_Depth_Of_Inheritance2";
            }
            catch (DivideByZeroException ex)
            {
                _message = "Test_Depth_Of_Inheritance2";
            }
            catch (Exception ex)
            {
                _message = "Test_Depth_Of_Inheritance2";
            }

            try
            {
                _message = "Test_Depth_Of_Inheritance12";
            }
            catch (DivideByZeroException ex)
            {
                _message = "Test_Depth_Of_Inheritance12";
            }
            catch (Exception ex)
            {
                _message = "Test_Depth_Of_Inheritance12";
            }

            return _message;
        }

        public string getDate22()
        {
            string _message = "";
            string d = "";
            switch (d) {
                case "A":
                    _message = "nameA";
                    break;
            }
            return _message;
        }
    }

    public partial class Test_Depth_Of_Inheritance3 : Test_Depth_Of_Inheritance2
    {
        public Test_Depth_Of_Inheritance3()
        {

        }

        public string getDate3()
        {
            return "Test_Depth_Of_Inheritance3";
        }

    }
}
