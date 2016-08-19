using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.UI.Workflows;

namespace SGFlooring.UI
{
    public class MainMenu
    {
        public void StartMenu()
        {
            bool quit = false;
            do
            {
                Console.Clear();
                int input = WorkFlows.IntPrompt("+****************************+\n" +
                                                "|                            |\n" +
                                                "|       SG Flooring          |\n" +
                                                "|                            |\n" +
                                                "|     1. Display Order       |\n" +
                                                "|                            |\n" +
                                                "|     2. Add an Order        |\n" +
                                                "|                            |\n" +
                                                "|     3. Edit an Order       |\n" +
                                                "|                            |\n" +
                                                "|     4. Remove an Order     |\n" +
                                                "|                            |\n" +
                                                "|     5. Quit                |\n" +
                                                "|                            |\n" +
                                                "|                            |\n" +
                                                "+****************************+\n" +
                                                "                              \n" +
                                                "      Enter Choice");
                switch (input)
                {
                    case 1:
                        DisplayWorkflow display = new DisplayWorkflow();
                        display.Execute();
                        break;
                    case 2:
                        AddOrderWorkflow add = new AddOrderWorkflow();
                        add.Execute();
                        break;
                    case 3:
                        EditOrderWorkflow edit = new EditOrderWorkflow();
                        edit.Execute();
                        break;
                    case 4:
                        RemoveWorkflow remove = new RemoveWorkflow();
                        remove.Execute();
                        break;
                    case 5:
                        quit = true;
                        break;
                }
            } while (!quit);
        }
    }
}
