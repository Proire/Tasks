using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Collections Usage");

            // 1. ArrayList - creation and initializes it 
            ArrayList arrayList = ["virat",10,true,20.5,'c'];
            arrayList.Add("pro");

            // Displaying the properties and values of Arraylist
            Console.WriteLine("arraylist");
            Console.WriteLine("    Count:    {0}", arrayList.Count);
            Console.WriteLine("    Capacity: {0}", arrayList.Capacity);
            Console.Write("    Values:");
            foreach(var element in arrayList)
            {
                Console.Write("   {0}", element);
            }
            Console.WriteLine();
            arrayList.Remove(10);
            if(arrayList.Contains(20.5)) { Console.WriteLine("20.5 is present in ArrayList"); }
            else { Console.WriteLine("20.5 is present in ArrayList"); }

            //arrayList.Sort();         Execption occured due to non-generic collection of different types cannot be compared by sort method
            var query = from s in arrayList.OfType<string>() select s;
            foreach(var i in query)
            {
                Console.Write(i+" ");  
            }


            // 2. Hashtable
            Hashtable hashtable = new Hashtable();
            hashtable.Add("txt", "notepad.exe");
            hashtable.Add("bmp", "paint.exe");
            hashtable.Add("dib", "paint.exe");
            hashtable.Add("rtf", "wordpad.exe");
            // hashtable.Add(null, "moxilla.exe"); not allowed key as null 
            hashtable.Add("pj", null);

            // The Add method throws an exception if the new key is already in the hash table.
            try
            {
                hashtable.Add("txt", "notepad++.exe");
            }
            catch
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            // Default property is Item Property(indexer) 
            Console.WriteLine("For key = \"rtf\", value = {0}.", hashtable["rtf"]);

            // Indexer to overwrite key value pair 
            hashtable["rtf"] = "winword.exe";
            Console.WriteLine("For key = \"rtf\", value = {0}.", hashtable["rtf"]);

            // Add new key value pair using indexer
            hashtable["doc"]= "winword.exe";

            // Containskey used to test keys before inserting them
            if (!hashtable.ContainsKey("ht"))
            {
                hashtable.Add("ht", "hypertrm.exe");
                Console.WriteLine("Value added for key = \"ht\": {0}", hashtable["ht"]);
            }

            // When you use foreach to enumerate hash table elements the elements are retrieved as KeyValuePair objects.(DictionaryEntry is a structure which has key and value as members)
            Console.WriteLine();
            foreach (DictionaryEntry de in hashtable)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }

            // To get the values alone, use the Values property.
            ICollection valueColl = hashtable.Values;
            Console.WriteLine();
            foreach (string s in valueColl)
            {
                Console.WriteLine("Value = {0}", s);
            }

            // To get the keys alone, use the Keys property.
            ICollection keyColl = hashtable.Keys;
            Console.WriteLine();
            foreach (string s in keyColl)
            {
                Console.WriteLine("Key = {0}", s);
            }

            // Use the Remove method to remove a key/value pair.
            Console.WriteLine("\nRemove(\"doc\")");
            hashtable.Remove("doc");

            if (!hashtable.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found.");
            }



            // 3. LinkedList - represents doubly linked list
            string[] words = {"you", "are", "talented", "then", "you", "are", "AB" };
            LinkedList<string> list = new LinkedList<string>(words);
            Console.WriteLine("The linked list values:");
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();

            // Add the word 'if' to beginning of linked list
            list.AddFirst("If");

            // Add the word 'Deviliers' at the end of linked list
            list.AddLast("Deviliers");

            Console.WriteLine("The linked list values:");
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();


            // Node type of linked list used to hold values and address
            LinkedListNode<string> node = list.First;
            Console.WriteLine(node.Value);

            //Manipulate using linked list node
            LinkedListNode<string> currentnode = list.FindLast("talented");
            list.AddAfter(currentnode, "Genius");
            list.AddBefore(list.FindLast("Genius"), "and");

            LinkedListNode<string> mark1 = currentnode;
            // The AddBefore method throws an InvalidOperationException if you try to add a node that already belongs to a list.
            Console.WriteLine("Test 10: Throw exception by adding node (fox) already in the list:");
            try
            {
                list.AddBefore(currentnode, mark1);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Exception message: {0}", ex.Message);
            }
            Console.WriteLine();

            Console.WriteLine("The linked list values:");
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();

            currentnode = list.Last;

            //Remove the element and add it before currentnode
            list.Remove(mark1);
            list.AddBefore(currentnode, mark1);

            string[] arrayoflinkedlist = new string[list.Count];
            foreach (string s in arrayoflinkedlist)
            {
                Console.WriteLine(s);
            }
        }
    }
}
