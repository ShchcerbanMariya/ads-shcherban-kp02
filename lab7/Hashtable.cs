using System;

namespace lab7
{
    class Hashtable
    {
        private int _size;
        private double _loadness;
        private int _capacity;
        private Entry[] hashtable;
        public Hashtable()
        {
            this._capacity = 11;
            this._loadness = 0;
            this._size = 0;
            this.hashtable = new Entry[this._capacity];
        }
        public void InsertEntry(Key key, Value value, AdditHashtable addTable, ref int index)
        {

            int hash_index = getHash(key);
            if (this._loadness > 0.6)
                Rehashing();
            for (int i = hash_index; i <= this._capacity; i++)
            {
                if (i == this._capacity) i = 0;
                if (hashtable[i].key.firstName == key.firstName && hashtable[i].key.lastName == key.lastName)
                {
                    CheckLimit(addTable, key, value, i);
                    addTable.RemovePatient(hashtable[i].key, hashtable[i].value);
                    hashtable[i].value.familyDoctor = value.familyDoctor;
                    hashtable[i].value.adress = value.adress;
                    addTable.InsertPatient(key, hashtable[i].value);
                    break;
                }
                if (hashtable[i].key.firstName == "DELETED" || hashtable[i].key.firstName == null)
                {
                    Entry check = findEntry(key);
                    if (check.key.firstName != null)
                    {
                        continue;
                    }
                    CheckLimit(addTable, key, value, i);
                    hashtable[i].key = key;
                    hashtable[i].value = value;
                    index++;
                    this._size++;
                    this._loadness = (double)this._size / this._capacity;
                    addTable.InsertPatient(key, value);
                    break;
                }
            }
        }
        public bool RemoveEntry(Key key, AdditHashtable addTab)
        {
            int hash_index = getHash(key);
            for (int i = hash_index; i <= this._capacity; i++)
            {
                if (i == this._capacity) i = 0;
                if (hashtable[i].key.firstName == null)
                    return false;
                if (hashtable[i].key.firstName == key.firstName && hashtable[i].key.lastName == key.lastName)
                {
                    addTab.RemovePatient(hashtable[i].key, hashtable[i].value);
                    hashtable[i].key.firstName = "DELETED";
                    this._size--;
                    this._loadness = (double)this._size / this._capacity;
                    break;
                }
            }
            return true;
        }
        private long HashCode(Key key)
        {
            long hash = 0;
            string hashable = key.firstName + key.lastName;
            for (int i = 0; i < hashable.Length; i++)
                hash += hashable[i] * (i + 1) * 89;
            return hash;
        }
        private int getHash(Key key)
        {
            return (int)(HashCode(key) % _capacity);
        }
        private void Rehashing()
        {
            Console.WriteLine("The table is loaded on more than 60%\nRehashing...");
            int oldCap = this._capacity;
            this._capacity *= 2;
            Entry[] newTab = new Entry[this._capacity];
            for (int i = 0; i < oldCap; i++)
            {
                if (hashtable[i].key.firstName == null || hashtable[i].key.firstName == "DELETED")
                    continue;
                int hash_index = getHash(hashtable[i].key);
                for (int j = hash_index; j <= this._capacity; j++)
                {
                    if (j == this._capacity) j = 0;
                    if (newTab[j].key.firstName == null)
                    {
                        newTab[j] = hashtable[i];
                        break;
                    }
                }
            }
            this._loadness = (double)this._size / this._capacity;
            hashtable = newTab;
            Console.WriteLine("Succesfully");
        }
        public void Print()
        {
            Console.WriteLine("");
            for (int i = 0; i < this._capacity; i++)
            {
                if (hashtable[i].key.firstName != null && hashtable[i].key.firstName != "DELETED")
                {
                    int id = this.hashtable[i].value.patientID;
                    string fn = this.hashtable[i].key.firstName;
                    string ln = this.hashtable[i].key.lastName;
                    string doc = this.hashtable[i].value.familyDoctor;
                    string adrs = this.hashtable[i].value.adress;
                    Console.WriteLine($"[{id}] {fn} {ln} [doc: {doc}] [adress: {adrs}]");
                }

            }
            Console.WriteLine("");
        }
        public Entry findEntry(Key key)
        {
            Entry nullEntry = new Entry();
            int hash_index = getHash(key);
            for (int i = hash_index; i <= this._capacity; i++)
            {
                if (i == this._capacity) i = 0;
                if (hashtable[i].key.firstName == key.firstName && hashtable[i].key.lastName == key.lastName)
                {
                    if (hashtable[i].key.firstName == "DELETED")
                        return nullEntry;
                    return hashtable[i];
                }
                if (hashtable[i].key.firstName == null)
                    break;
            }
            return nullEntry;
        }
        private void CheckLimit(AdditHashtable addTab, Key key, Value value, int i)
        {
            Entry2 doctor = addTab.FindDoctor(value.familyDoctor);
            if (doctor.doctor != null && doctor.patient.Count == 5)
            {
                if (hashtable[i].value.familyDoctor == doctor.doctor)
                    return;
                else
                    throw new Exception("This doctor is currently unavailable: he already have 5 patients.");
            }
        }
    }
}