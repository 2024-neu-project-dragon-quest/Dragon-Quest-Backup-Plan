namespace DragonQuest_Lib.ItemClasses
{
    public class Items
    {
        public List<Item> items = [];
        public Items(string l) {
            for (int i = 0; i < l.Split(";").Length; i++)
            {
                string[] itemAttrs = l.Split(";")[i].Replace("[", "").Replace("]", "").Split(",");
                Item item = new();

                foreach (string itemAttr in itemAttrs)
                {
                    switch (itemAttr.Split(":")[0])
                    {
                        case "ID":
                            item.id = int.Parse(itemAttr.Split(":")[1]);
                        break;
                        case "X":
                            item.x = int.Parse(itemAttr.Split(":")[1]);
                        break;
                        case "Y":
                            item.y = int.Parse(itemAttr.Split(":")[1]);
                        break;
                    }

                    if(item.id != 0 && item.name == null)
                    {
                        StreamReader f = new("Items.txt");
                        while (!f.EndOfStream)
                        {
                            string cl = f.ReadLine()!;
                            if (cl.Split("=")[0] == "ID" && int.Parse(cl.Split("=")[1]) == item.id)
                            {
                                item.name = string.Join(" ", f.ReadLine()!.Split("=")[1].Split(";"));
                            }
                        }
                    }

                    // > idiot.png
                    if (item.id != 0 && item.x != 0 && item.y != 0 && item.name != null)
                    {
                        items.Add(item);
                        item = new();
                    }
                }
            }
        }
    }
}
