using System;
using System.Linq;
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
        int ActualDatabaseVersion = 1;

        private static readonly MythDB instance = new MythDB();
        
        public static MythDB Instance
        {
            get { return instance; }
        }
        protected MythDB() 
        {
            
            string ConnectionString = "isostore:/mythquiz.sdf";
            Database = new MythDataContext(ConnectionString);
            {
                if (Database.DatabaseExists())
                {
                    // check for update                    
                    int DeployedDatabaseVersion = Database.DatabaseInfo.FirstOrDefault().Version;
                    if (DeployedDatabaseVersion < ActualDatabaseVersion)
                    {
                        Database.DeleteDatabase();
                    }
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
            // db version
            DatabaseInfo v = new DatabaseInfo();
            v.Version = this.ActualDatabaseVersion;
            Database.DatabaseInfo.InsertOnSubmit(v);

            // languages
            Language eng = new Language();
            eng.Name = "English";
            eng.IsCurrent = false;
            Database.Languages.InsertOnSubmit(eng);

            // nations
            Nation greekz = new Nation("Greek mythology", "gr" , true);
            Database.Nations.InsertOnSubmit(greekz);
            Nation scands = new Nation("Scandinavian (norse) mythology", "sc", true);
            Database.Nations.InsertOnSubmit(scands);
            Nation egipts = new Nation("Egyptian mythology", "eg", true);
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
            Database.Characters.InsertOnSubmit(new Character("Aega", "Daughter of Olenus, who was a descendant of Hephaestus (according to Hyginus). Aega and her sister Helice nursed the infant Zeus in Crete, and the former was afterwards changed by the god into the constellation called Capella.", greekz));
            Database.Characters.InsertOnSubmit(new Character("Pan", "God of Nature, the Wild, Shepherds, Flocks, Goats, of Mountain Wilds,and is often associated with sexuality", greekz));
            Database.Characters.InsertOnSubmit(new Character("Ananke", "Personification of destiny, necessity and fate, depicted as holding a spindle. She marks the beginning of the cosmos, along with Chronos. She was seen as the most powerful dictator of all fate and circumstance which meant that mortals, as well as the Gods, respected her and paid homage", greekz));
            Database.Characters.InsertOnSubmit(new Character("Atropos", "The oldest of the three Moirai, goddesses of fate and destiny, was known as the \"inflexible\" or \"inevitable.\"", greekz));
            Database.Characters.InsertOnSubmit(new Character("Clotho", "The youngest of the Three Fates or Moirai,  she was responsible for spinning the thread of human life. She also made major decisions, such as when a person was born, thus in effect controlling people's lives.", greekz));

            Database.Characters.InsertOnSubmit(new Character("Lachesis", "The second of the Three Fates, or Moirai. She was the apportioner, deciding how much time for life was to be allowed for each person or being. She measured the thread of life with her rod. She is also said to choose a person's destiny after a thread was measured", greekz));
            Database.Characters.InsertOnSubmit(new Character("Demeter", "Goddess of the harvest, who presided over grains and the fertility of the earth. Her cult titles include Sito as the giver of food or corn and Thesmophoros as a mark of the civilized existence of agricultural society", greekz));
            Database.Characters.InsertOnSubmit(new Character("Persephone", "Daughter of Zeus and the harvest-goddess Demeter, and queen of the underworld. Homer describes her as the formidable, venerable majestic queen of the shades, who carries into effect the curses of men upon the souls of the dead", greekz));
            Database.Characters.InsertOnSubmit(new Character("Dione", "Goddess primarily known as the mother of Aphrodite", greekz));
            Database.Characters.InsertOnSubmit(new Character("Eos", " A Titaness and the goddess of the Dawn, who rose each morning from her home at the edge of the Oceanus", greekz));
            Database.Characters.InsertOnSubmit(new Character("Ersa", "The goddess of dew and the daughter of Zeus and the Moon (Selene), sister of Pandia and half-sister to Endymion's 50 daughters", greekz));
            Database.Characters.InsertOnSubmit(new Character("Eris", "Goddess of strife and discord. Her Greek opposite is Harmonia, whose Latin counterpart is Concordia", greekz));
            Database.Characters.InsertOnSubmit(new Character("Orion", "A giant huntsman in Greek mythology whom Zeus placed among the stars", greekz));
            Database.Characters.InsertOnSubmit(new Character("Manes", "The eponymous first king of Maeonia, and later came to be known as the first king in line of the primordial house of Lydia, the Atyad dynasty. He was believed to be a son of Gaia and Zeus", greekz));
            Database.Characters.InsertOnSubmit(new Character("Nemesis", "The spirit of divine retribution against those who succumb to hubris (arrogance before the gods). Another name was Adrasteia, meaning \"the inescapable\". The Greeks personified vengeful fate as a remorseless goddess: the goddess of revenge", greekz));

            Database.Characters.InsertOnSubmit(new Character("Maia", "One of the Pleiades and the mother of Hermes, she was the daughter of Atlas and Pleione the Oceanid", greekz));
            Database.Characters.InsertOnSubmit(new Character("Selene", "Titaness of the Moon, an archaic lunar deity and the daughter of the Titans Hyperion and Theia", greekz));
            Database.Characters.InsertOnSubmit(new Character("Nemean lion", " The offspring of Typhon (or Orthrus) and Echidna; it is also said to have fallen from the moon as the offspring of Zeus and Selene, or alternatively born of the Chimera. He was sent to the Peloponnesus to terrorize the city", greekz));
            Database.Characters.InsertOnSubmit(new Character("Callisto", "A nymph of Artemis. Transformed into a bear and set among the stars, she was the bear-mother of the Arcadians, through her son Arcas", greekz));
            Database.Characters.InsertOnSubmit(new Character("Danaë", "A daughter of King Acrisius of Argos and his wife Queen Eurydice. She was the mother of Perseus by Zeus. She was sometimes credited with founding the city of Ardea in Latium", greekz));
            Database.Characters.InsertOnSubmit(new Character("Electra", "One of the seven daughters of Atlas and Pleione, she was the wife of Corythus. She was raped by Zeus and gave birth to Dardanus", greekz));
            Database.Characters.InsertOnSubmit(new Character("Harmonia", "The immortal goddess of harmony and concord, she is the daughter of Ares and Aphrodite", greekz));
            Database.Characters.InsertOnSubmit(new Character("Europa", "A Phoenician woman of high lineage. The story of her abduction by Zeus in the form of a white bull was a Cretan story; as Kerényi points out most of the love-stories concerning Zeus originated from more ancient tales describing his marriages with goddesses", greekz));
            Database.Characters.InsertOnSubmit(new Character("Rhadamanthus", "A wise king, the son of Zeus and Europa. Later accounts even make him out to be one of the judges of the dead. His brothers were Sarpedon and Minos (also a king and later a judge of the dead)", greekz));
            Database.Characters.InsertOnSubmit(new Character("Himalia", "A nymph in Greek mythology. Zeus was enamoured with her and she produced three sons with him, Spartaios, Kronios, and Kytos", greekz));

            Database.Characters.InsertOnSubmit(new Character("Leda", "Daughter of the Aetolian king Thestius, and wife of the king Tyndareus, of Sparta. Her myth gave rise to the popular motif in Renaissance and later art (with the swan). She was the mother of Helen of Troy, Clytemnestra, and Castor and Pollux", greekz));
            Database.Characters.InsertOnSubmit(new Character("Dioscuri", "Twin brothers,  their mother was Leda, but one of them was the mortal son of Tyndareus, king of Sparta, and the other was the divine son of Zeus, who raped Leda in the guise of a swan. Though accounts of their birth are varied, they are sometimes said to have been born from an egg, along with their twin sisters Helen of Troy and Clytemnestra", greekz));
            Database.Characters.InsertOnSubmit(new Character("Pandora", "The first woman. As Hesiod related it, each god helped create her by giving her unique gifts. Zeus ordered Hephaestus to mold her out of earth as part of the punishment of humanity for Prometheus' theft of the secret of fire, and all the gods joined in offering her \"seductive gifts\"", greekz));
            Database.Characters.InsertOnSubmit(new Character("Plouto", "A nymph and the mother of Tantalus by Zeus. Her parents were Oceanus and Tethys. or Himas, a Lydian that was otherwise unknown. She was said to be married to Tmolus, the stepfather of Tantalus", greekz));
            Database.Characters.InsertOnSubmit(new Character("Tantalus", "A mythological figure, most famous for his eternal punishment in Tartarus. He was made to stand in a pool of water beneath a fruit tree with low branches, with the fruit ever eluding his grasp, and the water always receding before he could take a drink. He was the father of Pelops, Niobe and Broteas, and was a son of Zeus and the nymph Plouto", greekz));            
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
            Database.Characters.InsertOnSubmit(new Character("Mjölnir", "The hammer of Thor, the Norse god of thunder. Distinctively shaped, Mjölnir is depicted in Norse mythology as one of the most fearsome weapons, capable of leveling mountains. Though generally recognized and depicted as a hammer, it is sometimes referred to as an axe or club.", scands));
            Database.Characters.InsertOnSubmit(new Character("Gylfaginning", "The first part of Snorri Sturluson's Prose Edda after Prologue. It deals with the creation and destruction of the world of the Norse gods, and many other aspects of Norse mythology", scands));
            Database.Characters.InsertOnSubmit(new Character("Skáldskaparmál", "The second part of Snorri Sturluson's Prose Edda, it is effectively a dialogue between Ægir, the Norse god of the sea, and Bragi, the god of poetry, in which both Norse mythology and discourse on the nature of poetry are intertwined. The origin of a number of kennings are given and Bragi then delivers a systematic list of kennings for various people, places and things", scands));
            Database.Characters.InsertOnSubmit(new Character("Snorri Sturluson", "An Icelandic historian, poet, and politician. He was twice elected lawspeaker at the Icelandic parliament, the Althing. He was the author of the Prose Edda or Younger Edda", scands));
            Database.Characters.InsertOnSubmit(new Character("Ægir", "A sea giant, god of the ocean and king of the sea creatures in Norse mythology. He is also known for hosting elaborate parties for the gods. His servants are Fimafeng (killed by Loki) and Eldir.", scands));

            Database.Characters.InsertOnSubmit(new Character("Háttatal", "The last section of the Prose Edda composed by the Icelandic poet, politician, and historian Snorri Sturluson. Using, for the most part, his own compositions, it exemplifies the types of verse forms used in Old Norse poetry. Snorri took a prescriptive as well as descriptive approach; he has systematized the material, and often notes that \"the older poets didn't always\" follow his rules.", scands));
            Database.Characters.InsertOnSubmit(new Character("Æsir", "A member of the principal pantheon in the indigenous European religion known as Norse paganism. This pantheon includes Odin, Frigg, Thor, Balder and Tyr", scands));
            Database.Characters.InsertOnSubmit(new Character("Baldr", "Son of Óðin, and the most gentle and most loved of the gods, suffered from nightmares. The Æsir, in counsel, could not unravel Baldr's dreams.", scands));
            Database.Characters.InsertOnSubmit(new Character("Vanir", "A group of gods associated with fertility, wisdom and the ability to see the future.", scands));
            Database.Characters.InsertOnSubmit(new Character("Týr", "The god of Law, the althing, Justice, The Sky, and heroic glory, portrayed as a one-handed man", scands));
            Database.Characters.InsertOnSubmit(new Character("Frigg", "A major goddess, she is said to be the wife of Odin, and is the \"foremost among the goddesses\" and the queen of Asgard. She is also described as having the power of prophecy yet she does not reveal what she knows. Frigg is described as the only one other than Odin who is permitted to sit on his high seat Hlidskjalf and look out over the univers", scands));
            Database.Characters.InsertOnSubmit(new Character("Fenrir", "A monstrous wolf, the father of the wolves Sköll and Hati Hróðvitnisson, he is a son of Loki, and is foretold to kill the god Odin during the events of Ragnarök, but will in turn be killed by Odin's son Víðarr", scands));
            Database.Characters.InsertOnSubmit(new Character("Jörmungandr", "A sea serpent, the middle child of the giantess Angrboða and the god Loki. he serpent grew so large that he was able to surround the earth and grasp his own tail. As a result, he received the name of the Midgard Serpent or World Serpent. When he lets go, the world will end. His arch-enemy is the god Thor", scands));
            Database.Characters.InsertOnSubmit(new Character("Jötunn", "A mythological race, separate from the Æsir and Vanir but of comparable strength and ability", scands));
            Database.Characters.InsertOnSubmit(new Character("Forseti", "An Æsir god of justice and reconciliation in Norse mythology", scands));

            Database.Characters.InsertOnSubmit(new Character("Dellingr", "The father of Dagr, the personified day. The Prose Edda adds that he is either the third husband of Nótt, the personified night, or the husband of Jörð, the personified day.", scands));
            Database.Characters.InsertOnSubmit(new Character("Vanaheimr", "One of the Nine Worlds and home of the Vanir, a group of gods associated with fertility, wisdom, and the ability to see the future", scands));
            Database.Characters.InsertOnSubmit(new Character("Útgarðar", "One of the divisions of Jotunheim, land of the giants, ruled by Utgard-Loki, a great and devious giant featured in one of the myths concerning Thor and the other Loki who compete in rigged competitions held in the Outyards", scands));
            Database.Characters.InsertOnSubmit(new Character("Álfheimr", "One of the Nine Worlds and home of the Light Elves in Norse mythology and appears also in Anglo-Scottish ballads under the form Elfhame (Elphame, Elfame) as a fairyland, sometimes modernized as Elfland (Elfinland, Elvenland)", scands));
            Database.Characters.InsertOnSubmit(new Character("Surtr", "An elder jötunn, that is foretold as being a major figure during the events of Ragnarök; carrying his bright sword, he will go to battle against the Æsir, he will do battle with the major god Freyr, and afterward the flames that he brings forth will engulf the Earth", scands));
            Database.Characters.InsertOnSubmit(new Character("Bifröst", "A burning rainbow bridge that reaches between Midgard (the world) and Asgard, the realm of the gods. This bridge ends in heaven at Himinbjörg, the residence of the god Heimdallr, who guards it from the jötnar. The bridge's destruction at Ragnarök by the forces of Muspell is foretold. Scholars have proposed that the bridge may have originally represented the Milky Way and have noted parallels between the bridge and another bridge in Norse mythology, Gjallarbrú", scands));
            Database.Characters.InsertOnSubmit(new Character("Muspelheim", "A realm of fire. This realm is one of the Nine Worlds and it is home to the fire jötunn. It is fire; and the land to the North, Niflheim, is ice. The two mixed and created water from the melting ice in Ginnungagap", scands));
            Database.Characters.InsertOnSubmit(new Character("Svartálfar", "Beings who dwell in Svartálfaheimr", scands));
            Database.Characters.InsertOnSubmit(new Character("Dwarf", "A being that dwells in mountains and in the earth, and is associated with wisdom, smithing, mining, and crafting. They are also described as short and ugly, although some scholars have questioned whether this is a later development stemming from comical portrayals of the beings", scands));
            Database.Characters.InsertOnSubmit(new Character("Einherjar", "Those that have died in battle and are brought to Valhalla by valkyries. In Valhalla, they eat their fill of the nightly-resurrecting beast Sæhrímnir, and are brought their fill of mead (from the udder of the goat Heiðrún) by valkyries. They prepare daily for the events of Ragnarök, when they will advance for an immense battle at the field of Vígríðr", scands));

            Database.Characters.InsertOnSubmit(new Character("Hel", "A being who presides over a realm of the same name, where she receives a portion of the dead", scands));
            Database.Characters.InsertOnSubmit(new Character("Vígríðr", "A large field foretold to host a battle between the forces of the gods and the forces of Surtr as part of the events of Ragnarök", scands));
            Database.Characters.InsertOnSubmit(new Character("Hvergelmir", "The wellspring of cold in Niflheim. All cold rivers are said to come from here, and it was said to be the source of the eleven rivers, Élivágar. Above the spring, the serpent Níðhöggr gnaws on one of the roots of the world tree, Yggdrasil", scands));
            Database.Characters.InsertOnSubmit(new Character("Ginnungagap", "The vast, primordial void that existed prior to the creation of the manifest universe", scands));
            Database.Characters.InsertOnSubmit(new Character("Ymir", "A primeval being born of primordial elemental poison and the ancestor of all jötnar", scands));
            Database.Characters.InsertOnSubmit(new Character("Gjöll", "One of the eleven rivers traditionally associated with the Élivágar, according to Gylfaginning, originating from the wellspring Hvergelmir in Niflheim, flowing through Ginnungagap, and thence into the worlds of existence. In Hel, it is the river that flows closest to the gate of the underworld and is spanned by the bridge Gjallarbrú, which was crossed by Hermód during his quest to retrieve Baldr from the land of the dead", scands));
            Database.Characters.InsertOnSubmit(new Character("Garmr", "A dog associated with Ragnarök, and described as a blood-stained watchdog that guards Hel's gate", scands));
            Database.Characters.InsertOnSubmit(new Character("Járnviðr", "Aforest located east of Midgard, inhabited by troll women who bore giantesses and giant wolves", scands));
            Database.Characters.InsertOnSubmit(new Character("Angrboða", "A female jötunn (giantess) who was the mother of Loki's children, Fenrir and Hel, and also of the Midgard serpent.", scands));
            Database.Characters.InsertOnSubmit(new Character("Líf and Lífþrasir", "Two humans who are foretold to survive the events of Ragnarök by hiding in a wood called Hoddmímis holt, and after the flames have abated, to repopulate the newly risen and fertile world", scands));

            Database.Characters.InsertOnSubmit(new Character("Bilskirnir", "The hall of the god Thor, here he lives with his wife Sif and their children. According to Grímnismál, the hall is the greatest of buildings and contains 540 rooms, located in Asgard, as are all the dwellings of the gods, in the kingdom of Þrúðheimr", scands));
            Database.Characters.InsertOnSubmit(new Character("Norns", "Female beings who rule the destiny of gods and men, a kind of dísir comparable to the Fates in Greek mythology", scands));
            Database.Characters.InsertOnSubmit(new Character("Valkyrie", "One of a host of female figures who decide which soldiers die in battle and which live. Selecting among half of those who die in battle (the other half go to the goddess Freyja's afterlife field Fólkvangr), they bring their chosen to the afterlife hall of the slain, Valhalla, ruled over by the god Odin. There, the deceased warriors become einherjar", scands));
            Database.Characters.InsertOnSubmit(new Character("Brynhildr", "A shieldmaiden and a valkyrie in Norse mythology, who is the daughter of Budli. She appears as a main character in the Völsunga saga and some Eddic poems treating the same events", scands));
            Database.Characters.InsertOnSubmit(new Character("Thrúd", "A daughter of the major god Thor. It is also the name of one of the valkyries who serve ale to the einherjar in Valhalla", scands));
            Database.Characters.InsertOnSubmit(new Character("Gullfaxi", "A horse in Norse mythology. Its name means Golden mane. It was originally owned by Hrungnir, and was later given to Magni by Thor as a reward for helping him in the fight against Hrungnir", scands));
            Database.Characters.InsertOnSubmit(new Character("Auðumbla", "The primeval cow of Norse mythology. She is attested in Gylfaginning, a part of Snorri Sturluson's Prose Edda, in association with Ginnungagap and Ymir", scands));            
            //Database.Characters.InsertOnSubmit(new Character("", "", scands));
            /*
             If you find some errors in quiz content, please email us: wp-myth-quiz@gmail.com             
             */
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

            Database.Characters.InsertOnSubmit(new Character("Imiut", "A stuffed, headless animal skin, often a feline or bull, which was tied by the tail to a pole terminating in a lotus bud, inserted into a stand", egipts));
            Database.Characters.InsertOnSubmit(new Character("Djed", "A pillar-like symbol in hieroglyphics representing stability. It is associated with Osiris, the Egyptian god of the afterlife, the underworld, and the dead. It is commonly understood to represent his spine.", egipts));
            Database.Characters.InsertOnSubmit(new Character("Ankh", "The ancient Egyptian hieroglyphic character that read \"life\", the Egyptian gods are often portrayed carrying it by its loop, or bearing one in each hand, arms crossed over their chest", egipts));
            Database.Characters.InsertOnSubmit(new Character("Eye of Horus", "An ancient symbol of protection, royal power and good health. The eye is personified in the goddess Wadjet. It is also known as 'The Eye of Ra'", egipts));
            Database.Characters.InsertOnSubmit(new Character("Was", "A stylized animal head at the top of a long, straight staff with a forked end", egipts));
            Database.Characters.InsertOnSubmit(new Character("Mut", "Goddess of queens and lady of heaven. She also was depicted as a woman with the crowns of Egypt upon her head.", egipts));
            Database.Characters.InsertOnSubmit(new Character("Horus", "God of the king and vengeance.  He was usually depicted as a falcon-headed man wearing the pschent, or a red and white crown, as a symbol of kingship over the entire kingdom of Egypt", egipts));
            Database.Characters.InsertOnSubmit(new Character("Unut", "A prehistoric Egyptian snake goddess", egipts));
            Database.Characters.InsertOnSubmit(new Character("Atum", "God of creation, finisher of the world. He  was considered to be the first god, having created himself, sitting on a mound (benben) (or identified with the mound itself), from the primordial waters (Nu)", egipts));
            Database.Characters.InsertOnSubmit(new Character("Buchis", "The manifestation of the deification of Ka (power/life-force) of the war god Menthu, worshipped in the region of Hermonthis", egipts));

            Database.Characters.InsertOnSubmit(new Character("Mnevis", " The bull, the Son of Ptah, and the symbol of the Sun-god Ra, as Apis was supposed to be Osiris in the sacred bull-form. His abode was at Heliopolis, the City of the Sun. He was black and carried on his horns the sacred ureus and disk", egipts));
            Database.Characters.InsertOnSubmit(new Character("Apis", "The Egyptian god of strength and fertility, He was depicted as a bull. His spirit was said to be present in the body of a real bull which was kept by the Pharaoh and looked after by his priests", egipts));
            Database.Characters.InsertOnSubmit(new Character("Serapis", "An anthropomorphic god created by the Greek pharaoh Ptolemy I. Ptolemy I chose him to be the official god of Egypt and Greece. Serapis' attributes were both Egyptian and Hellenistic", egipts));
            Database.Characters.InsertOnSubmit(new Character("Ammit", "A female demon with a body that was part lion, hippopotamus and crocodile. A funerary deity, her titles included \"Devourer of the Dead\", \"Eater of Hearts\", and \"Great of Death\".", egipts));
            Database.Characters.InsertOnSubmit(new Character("Huh", "One of the oldest Egyptian gods in ancient Egyptian history, the deification of eternity in the Ogdoad. He was the god of infinity and time, the god of long life and eternity. He has no gender, but has the aspect that can represent as male or female.", egipts));
            Database.Characters.InsertOnSubmit(new Character("Kuk", "The deification of the primordial concept of darkness. His male form was depicted as a frog, or as a frog-headed man, and the female form as a snake, or a snake-headed woman. As a symbol of darkness, He also represented obscurity and the unknown, and thus chaos", egipts));
            Database.Characters.InsertOnSubmit(new Character("Nu", "The deification of the primordial watery abyss. He was depicted as a bearded man with rippled blue skin symbolizing water. Sometimes he was portrayed with a woman’s breasts to demonstrate his aspect as a fertility god. His symbols were palm fronds which represent long life and he is often shown wearing one in his hair and carrying one in his hand", egipts));
            Database.Characters.InsertOnSubmit(new Character("Ogdoad", "Eight deities worshipped in Hermopolis during what is called the Old Kingdom (Naunet and Nu, Amaunet and Amun, Kauket and Kuk, Hauhet and Huh). The females were associated with snakes and the males were associated with frogs,", egipts));
            Database.Characters.InsertOnSubmit(new Character("Aten", "A being who represented the god or spirit of the sun, and the actual solar disk. He was depicted as a disk with rays reaching to the earth. At the end of the rays were human hands which often extended the ankh to the pharaoh", egipts));           
            //Database.Characters.InsertOnSubmit(new Character("", "", egipts));
            
            Database.SubmitChanges();
        }
    }
}
