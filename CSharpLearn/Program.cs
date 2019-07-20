using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = GetItems();            
            var blueItems2 = items.Where(IsBlue);
            var parentItems1 = items.Select((x) => new ParentItem(x));
            var parentItems2 = items.Select(GetParent);

            items.ForEach(DoAction);

            var isTrue = true;

            isTrue = UseFunc(x => x > 0);
            isTrue = UseExpression(x => x > 0);


            isTrue = UseFunc(x => {
                return x > 0;
            });

            // isTrue = UseExpression(x => {
            //     return x > 0;
            // });

        }

        public static void DoAction(Item item)
        {
          
        }

        public static bool UseFunc(Func<int, bool> method)
        {
            int a = 0;
            return method(a);
        }
        public static bool UseExpression(Expression<Func<int, bool>> method)
        {
            int a = 0;
            return method.Compile()(a);
        }

        private static bool IsBlue(Item item)
        {
            return item.color == ColorShade.Blue;
        }

        private static ParentItem GetParent(Item item)
        {
            return new ParentItem(item);
        }

        private static List<Item> GetItems()
        {
            var listItems = new List<Item>
            {
                new Item {color = ColorShade.Black },
                new Item {color = ColorShade.Black },
                new Item {color = ColorShade.Blue },
                new Item {color = ColorShade.White },
                new Item {color = ColorShade.Red },
                new Item {color = ColorShade.Red },
                new Item {color = ColorShade.White },
                new Item {color = ColorShade.White },
                new Item {color = ColorShade.Red },
                new Item {color = ColorShade.Red },
                new Item {color = ColorShade.Green },
                new Item {color = ColorShade.Green },
                new Item {color = ColorShade.Green },
            };
            return listItems;
        }
    }
}
