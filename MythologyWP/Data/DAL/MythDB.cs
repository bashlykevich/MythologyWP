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
using MythologyWP.Data.DAO;

namespace MythologyWP.Data.DAL
{
    public class MythDB
    {
         private static readonly MythDB instance = new MythDB();
        public static MythDB Instance
        {
            get { return instance; }
        }
        protected MythDB() 
        {
            string ConnectionString = "isostore:/MythologyWP.sdf";
            Database = new MythDataContext(ConnectionString);
            {
                if (Database.DatabaseExists())
                {
                    //Database.DeleteDatabase();
                }
                if (!Database.DatabaseExists())
                {                                                    
                    Database.CreateDatabase();
                    FillDatabase();
                }
            }
        }        
        public MythDataContext Database;
        
        void FillDatabase()
        {
            // languages
            Language eng = new Language();
            eng.Name = "English";
            eng.IsCurrent = false;
            Database.Languages.InsertOnSubmit(eng);

            // nations
            Nation greekz = new Nation("Greek mythology", true);
            Database.Nations.InsertOnSubmit(greekz);
            Nation scands = new Nation("Scandinavian (norse) mythology", true);
            Database.Nations.InsertOnSubmit(scands);
            Nation egipts = new Nation("Egyptian mythology", true);
            Database.Nations.InsertOnSubmit(egipts);
            
            // characters            
            Database.Characters.InsertOnSubmit(new Character("Zeus", "King of the Gods, God of the Sky, Thunder and Lightning and Law, Order and Justice", greekz));
            Database.Characters.InsertOnSubmit(new Character("Hera", "Queen of the Gods, Goddess of Marriage, Women and Birth", greekz));
            Database.Characters.InsertOnSubmit(new Character("Ares", "God of War", greekz));
            Database.Characters.InsertOnSubmit(new Character("Athena", "Goddess of Wisdom, Warfare, Divine intelligence, Architecture and Crafts (but commanly known as goddess of war and wisdom)", greekz));
            Database.Characters.InsertOnSubmit(new Character("Artemis", "Goddess of the Hunt, Forests and Hills, the Moon", greekz));
            Database.Characters.InsertOnSubmit(new Character("Apollo", "God of music, poetry, plague, oracles, sun, medicine, light and knowledge", greekz));
            Database.Characters.InsertOnSubmit(new Character("Cronus", "The leader and the youngest of the first generation of Titans, divine descendants of Gaia, the earth, and Uranus, the sky", greekz));
            Database.Characters.InsertOnSubmit(new Character("Rhea", "The Titaness daughter of the sky god Uranus and the earth goddess Gaia", greekz));
            Database.Characters.InsertOnSubmit(new Character("Dionysus", "God of Wine, Merry Making, Theatre and Ecstasy", greekz));
            Database.Characters.InsertOnSubmit(new Character("Hebe", "Cupbearer to the gods, Goddess of eternal youth", greekz));
            Database.Characters.InsertOnSubmit(new Character("Hermes", "Messenger of the gods, God of commerce, thieves, travelers, sports, athletes, and border crossings, fish, guide to the Underworld", greekz));
            Database.Characters.InsertOnSubmit(new Character("Heracles", "Gatekeeper of Olympus, God of heroes, sports, athletes, health, agriculture, fertility, trade, oracles and divine protector of mankind", greekz));
            Database.Characters.InsertOnSubmit(new Character("Helen of Troy", "The daughter of Zeus and Leda (or Nemesis), step-daughter of King Tyndareus, wife of Menelaus and sister of Castor, Polydeuces and Clytemnestra", greekz));
            Database.Characters.InsertOnSubmit(new Character("Hephaestus", "God of Fire, Metalworking, Stone masonry, and the Art of Sculpture", greekz));
            Database.Characters.InsertOnSubmit(new Character("Perseus", "The first of the heroes of Greek mythology whose exploits in defeating various archaic monsters provided the founding myths of the Twelve Olympians. Perseus was the Greek hero who killed the Gorgon Medusa, and claimed Andromeda, having rescued her from a sea monster sent by Poseidon in retribution for Queen Cassiopeia declaring that her daughter, Andromeda, was more beautiful than the Nereids", greekz));
            Database.Characters.InsertOnSubmit(new Character("Minos", "King of Crete, son of Zeus and Europa. After the death, he became a judge of the dead in the underworld", greekz));
            Database.Characters.InsertOnSubmit(new Character("Calliope", "The muse of epic poetry, daughter of Zeus and Mnemosyne, and is believed to be Homer's muse, the inspiration for the Odyssey and the Iliad", greekz));
            Database.Characters.InsertOnSubmit(new Character("Clio", "The muse of history. Like all the muses, she is a daughter of Zeus and Mnemosyne. She had one son, Hyacinth, with one of several kings, in various myths - with Pierus, King of Macedon, or with king Oebalus of Sparta, or with king Amyclas, progenitor of the people of Amyclae, dwellers about Sparta", greekz));
            Database.Characters.InsertOnSubmit(new Character("Erato", "The Muse of lyric poetry, especially love and erotic poetry", greekz));
            Database.Characters.InsertOnSubmit(new Character("Euterpe", "One of the Muses, the daughters of Mnemosyne, fathered by Zeus. Called the \"Giver of delight\", when later poets assigned roles to each of the Muses, she was the muse of music. In late Classical times she was named muse of lyric poetry and depicted holding a flute", greekz));
            Database.Characters.InsertOnSubmit(new Character("Melpomene", "Initially the Muse of Singing, she then became the Muse of Tragedy, for which she is best known now", greekz));
            Database.Characters.InsertOnSubmit(new Character("Polyhymnia", "The Muse of sacred poetry, sacred hymn and eloquence as well as agriculture and pantomime", greekz));
            Database.Characters.InsertOnSubmit(new Character("Terpsichore", "One of the nine Muses, ruling over dance and the dramatic chorus", greekz));
            Database.Characters.InsertOnSubmit(new Character("Thalia", "The Muse who presided over comedy and idyllic poetry. In this context her name means \"flourishing\", because the praises in her songs flourish through time. She was the daughter of Zeus and Mnemosyne, the eighth-born of the nine Muses", greekz));
            Database.Characters.InsertOnSubmit(new Character("Urania", "The muse of astronomy and a daughter of Zeus by Mnemosyne and also a granddaughter of Uranus. Some accounts list her as the mother of the musician Linus by Apollo, and Hymenaeus also is said to have been a son of her", greekz));
            Database.Characters.InsertOnSubmit(new Character("Graces", "Goddesses of charm, beauty, nature, human creativity and fertility", greekz));
            Database.Characters.InsertOnSubmit(new Character("Gaia", "Primordial Being of the Earth", greekz));
            Database.Characters.InsertOnSubmit(new Character("Amalthea", "The most-frequently mentioned foster-mother of Zeus", greekz));
            Database.Characters.InsertOnSubmit(new Character("Oceanus", "Titan of Water, Seas, Lakes, Rivers, Oceans, Streams and Ponds", greekz));
            Database.Characters.InsertOnSubmit(new Character("Aphrodite", "Goddess of love, beauty and sexuality", greekz));
            Database.Characters.InsertOnSubmit(new Character("Leto", "A daughter of the Titans Coeus and Phoebe and the sister of Asteria. The island of Kos is claimed as her birthplace", greekz));
            Database.Characters.InsertOnSubmit(new Character("Enyo", "An ancient goddess of war, acting as a counterpart and companion to the war god Ares. She is also identified as his sister, and daughter of Zeus and Hera, in a role closely resembling that of Eris; with Homer in particular representing the two as the same goddess. She is also accredited as the mother of Enyalius, a minor war god, by Ares", greekz));
            Database.Characters.InsertOnSubmit(new Character("Poseidon", "God of the sea, earthquakes, storms, and horses", greekz));
            Database.Characters.InsertOnSubmit(new Character("Phoebe", "One of the original Titans, who were one set of sons and daughters of Uranus and Gaia. She was traditionally associated with the moon. Her consort was her brother Coeus, with whom she had two daughters, Leto, who bore Apollo and Artemis, and Asteria, a star-goddess who bore an only daughter Hecate", greekz));
            Database.Characters.InsertOnSubmit(new Character("Mnemosyne", "The personification of memory in Greek mythology. This titaness was the daughter of Gaia and Uranus and the mother of the nine Muses by Zeus", greekz));            
            //Database.Characters.InsertOnSubmit(new Character("", "", greekz));

            Database.Characters.InsertOnSubmit(new Character("Odin", "A major god in Norse mythology and the ruler of Asgard", scands));
            Database.Characters.InsertOnSubmit(new Character("Asgard", "One of the Nine Worlds and home to the Norse gods of the Æsir. It is surrounded by an incomplete wall attributed to a Hrimthurs riding the stallion Svaðilfari, according to Gylfaginning. Odin and his wife, Frigg, are the rulers of this world", scands));
            Database.Characters.InsertOnSubmit(new Character("Bragi", "The skaldic god of poetry in Norse mythology", scands));
            Database.Characters.InsertOnSubmit(new Character("Freyr", "One of the most important gods of Norse paganism, associated with sacral kingship, virility and prosperity, with sunshine and fair weather, and was pictured as a phallic fertility god", scands));
            Database.Characters.InsertOnSubmit(new Character("Loki", "A god or jötunn (or both), the son of Fárbauti and Laufey, and the brother of Helblindi and Býleistr. By the jötunn Angrboða, he is the father of Hel, the wolf Fenrir, and the world serpent Jörmungandr", scands));
            Database.Characters.InsertOnSubmit(new Character("Thor", "A hammer-wielding god associated with thunder, lightning, storms, oak trees, strength, the protection of mankind, and also hallowing, healing and fertility", scands));
            Database.Characters.InsertOnSubmit(new Character("Freyja", "A goddess associated with love, beauty, fertility, gold, seiðr, war, and death. She is the owner of the necklace Brísingamen, rides a chariot pulled by two cats, owns the boar Hildisvíni, possesses a cloak of falcon feathers, and, by her husband Óðr, is the mother of two daughters, Hnoss and Gersemi", scands));
            Database.Characters.InsertOnSubmit(new Character("Gná", "A goddess who runs errands in other worlds for the goddess Frigg and rides the flying, sea-treading horse Hófvarpnir", scands));
            Database.Characters.InsertOnSubmit(new Character("Hófvarpnir", "The flying, sea-treading horse rided by Gná", scands));
            Database.Characters.InsertOnSubmit(new Character("Jötunheimr", "One of the Nine Worlds and the homeland (heim 'home') of the Giants of Norse Mythology — Rock Giants and Frost Giants", scands));
            Database.Characters.InsertOnSubmit(new Character("Midgard", "The name for the world (in the sense of oikoumene) inhabited by and known to humans in early Germanic cosmology, and specifically one of the Nine Worlds in Norse mythology", scands));
            Database.Characters.InsertOnSubmit(new Character("Niflheim", "A realm of primordial ice and cold, with nine frozen rivers. According to Gylfaginning, it was one of the two primordial realms", scands));
            Database.Characters.InsertOnSubmit(new Character("Valhalla", "A majestic, enormous hall located in Asgard, ruled over by the god Odin. Chosen by Odin, half of those who die in combat travel there upon death, led by valkyries, while the other half go to the goddess Freyja's field Fólkvangr", scands));
            Database.Characters.InsertOnSubmit(new Character("Yggdrasil", "An immense tree that is central in Norse cosmology, on which the nine worlds existed", scands));
            Database.Characters.InsertOnSubmit(new Character("Ragnarök", "A series of future events, including a great battle foretold to ultimately result in the death of a number of major figures (including the gods Odin, Thor, Týr, Freyr, Heimdallr, and Loki), the occurrence of various natural disasters, and the subsequent submersion of the world in water. Afterward, the world will resurface anew and fertile, the surviving and returning gods will meet, and the world will be repopulated by two human survivors", scands));
            //Database.Characters.InsertOnSubmit(new Character("", "", scands));

            Database.Characters.InsertOnSubmit(new Character("Ra", "God of the Sun. In one of his many forms, he has the head of a falcon and the sun-disk resting on his head.", egipts));
            Database.Characters.InsertOnSubmit(new Character("Thoth", "God of Knowledge, Hieroglyphs and Wisdom, in one of his forms as an ibis-headed man", egipts));
            Database.Characters.InsertOnSubmit(new Character("Amun", "King of the Gods, a local deity of Thebes. He was attested since the Old Kingdom together with his spouse Amaunet", egipts));
            Database.Characters.InsertOnSubmit(new Character("Anubis", "Protector of the dead and embalming, a jackal-headed god associated with mummification and the afterlife in ancient Egyptian religion. He is the son of Nephthys and Set according to the Egyptian mythology", egipts));
            Database.Characters.InsertOnSubmit(new Character("Sobek", "God of the Nile, the Army and Military. He was depicted as a crocodile or a man with the head of a crocodile", egipts));            
            Database.Characters.InsertOnSubmit(new Character("Wadjet", "Ancient local goddess of the city of Dep (Buto), she was said to be the patron and protector of Lower Egypt and upon unification with Upper Egypt, the joint protector and patron of all of Egypt with the \"goddess\" of Upper Egypt", egipts));
            Database.Characters.InsertOnSubmit(new Character("Khepri", "God of rebirth and the sunrise, often represented as a scarab, or a scarab-headed man, holding aloft the morning sun", egipts));
            Database.Characters.InsertOnSubmit(new Character("Geb", "Egyptian god of the Earth and a member of the Ennead of Heliopolis. It was believed in ancient Egypt that his laughter were earthquakes and that he allowed crops to grow", egipts));
            Database.Characters.InsertOnSubmit(new Character("Tefnut", "Goddess of moisture, moist air, dew and rain in Ancient Egyptian religion. She is the sister and consort of the air god Shu and the mother of Geb and Nut", egipts));
            Database.Characters.InsertOnSubmit(new Character("Set", "God of the desert, storms, and foreigners in ancient Egyptian religion. In later myths he is also the god of darkness, and chaos", egipts));
            Database.Characters.InsertOnSubmit(new Character("Osiris", "Egyptian god, usually identified as the god of the afterlife, the underworld and the dead. He was classically depicted as a green-skinned man with a pharaoh's beard, partially mummy-wrapped at the legs, wearing a distinctive crown with two large ostrich feathers at either side, and holding a symbolic crook and flail", egipts));
            Database.Characters.InsertOnSubmit(new Character("Nut", "Goddess of the sky in the Ennead of Egyptian mythology. She was seen as a star-covered nude woman arching over the earth, or as a cow", egipts));
            Database.Characters.InsertOnSubmit(new Character("Bes", "an Ancient Egyptian deity worshipped as a protector of households, and in particular, of mothers and children and childbirth. He later came to be regarded as the defender of everything good and the enemy of all that is bad", egipts));
            Database.Characters.InsertOnSubmit(new Character("Apep", "Evil god in ancient Egyptian religion, the deification of darkness and chaos (ı͗zft in Egyptian), and thus opponent of light and Ma'at (order/truth), whose existence was believed from the 8th Dynasty (mentioned at Moalla) onwards", egipts));
            Database.Characters.InsertOnSubmit(new Character("Bastet", "Goddess of Cats, Lower Egypt, the sun and the moon", egipts));
            Database.Characters.InsertOnSubmit(new Character("Sekhmet", "The warrior goddess as well as goddess of healing for Upper Egypt. She is depicted as a lioness, the fiercest hunter known to the Egyptians. It was said that her breath created the desert. She was seen as the protector of the pharaohs and led them in warfare", egipts));
            Database.Characters.InsertOnSubmit(new Character("Hathor", "Sky-goddess of love, beauty, motherhood, foreign lands, mining, and music. She was one of the most important and popular deities throughout the history of Ancient Egypt", egipts));
            Database.Characters.InsertOnSubmit(new Character("Ptah", "God of creation, the arts and fertility,  demiurge of Memphis. In the triad of Memphis, he is the husband of Sekhmet and the father of Nefertum. He was also regarded as the father of the sage Imhotep", egipts));
            Database.Characters.InsertOnSubmit(new Character("Isis", "Goddess of motherhood, magic and fertilityin Ancient Egyptian religious beliefs, whose worship spread throughout the Greco-Roman world. She was worshipped as the ideal mother and wife as well as the patroness of nature and magic. She was the friend of slaves, sinners, artisans, and the downtrodden, and she listened to the prayers of the wealthy, maidens, aristocrats, and rulers", egipts));
            //Database.Characters.InsertOnSubmit(new Character("", "", egipts));


            
            Database.SubmitChanges();
        }
    }
}
