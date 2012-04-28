using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JawBook;
using System.Drawing;

namespace WebSite.Members
{
    public partial class Rent : System.Web.UI.Page
    {
        private Db db = new Db();
        private Guid JawId;
        private Jaw jaw;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cStart.SelectedDate = DateTime.Now;
                cEnd.SelectedDate = DateTime.Now.AddDays(3);
            }
            if (Guid.TryParse(Request.Params["Id"], out JawId) && ((jaw = db.Jaws.Include("Race").FirstOrDefault(x => x.JawId == JawId)) != null))
            {
                PictureLabel.ImageUrl = string.Format("../getPic.ashx?Id={0}", JawId);
                NameLabel.Text = jaw.Name;
                AgeLabel.Text = jaw.Age;
                PriceLabel.Text = string.Format("{0} EUR", jaw.Price);
                RaceLabel.Text = jaw.Race.Name;
            }
            else
            {
                Response.Redirect("~/Members/Browse.aspx");
            }
        }

        protected void btnRent_Click(object sender, EventArgs e)
        {
            var tbs = new List<TextBox>() { tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tb15, tb16 };
            var missingRequired = false;
            foreach (var item in tbs)
            {
                if (string.Empty.Equals(item.Text.Trim()))
                {
                    missingRequired = true;
                    item.BorderColor = Color.Red;
                    item.BackColor = Color.LightPink;
                }
                else
                {
                    item.BorderColor = System.Drawing.SystemColors.InactiveBorder;
                    item.BackColor = SystemColors.Window;
                }
            }
            if (!missingRequired)
            {
                var rent = new JawBook.Rent()
                {
                    RentId = Guid.NewGuid(),
                    Jaw = jaw,
                    Start = cStart.SelectedDate,
                    End = cEnd.SelectedDate
                };
                db.Rents.Add(rent);
                db.SaveChanges();
                Response.Redirect(string.Format("~/Members/FeedBack.aspx?Id={0}", rent.RentId));
            }
        }

        protected void btnHelp_Click(object sender, EventArgs e)
        {
            var r = new Random();
            var tbs = new List<TextBox>() { tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tb15, tb16 };
            foreach (var item in tbs)
            {
                item.Text = string.Format("{0} {1} {2} {3}", words[r.Next(words.Count)], words[r.Next(words.Count)], words[r.Next(words.Count)], words[r.Next(words.Count)]);
            }
        }

        private List<string> words = new List<string>() {"canada","hello","ranger","shadow","baseball","donald","harley","hockey","letmein","maggie","mike","mustang","snoopy","buster","dragon","jordan","michael","michelle","mindy","patrick","andrew",
            "bear","calvin","changeme","diamond","fuckme","fuckyou","matthew","miller","tiger","alex","apple","avalon","brandy","chelsea","coffee","dave","falcon","freedom","gandalf","golf","green","helpme","linda","magic","merlin","molson","newyork","soccer",
            "thomas","wizard","Monday","asdfgh","bandit","batman","boris","butthead","dorothy","eeyore","fishing","football","george","happy","iloveyou","jennifer","jonathan","love","marina","master","missy","monday","monkey","natasha","newpass","pamela","pepper",
            "piglet","poohbear","pookie","rabbit","rachel","rocket","rose","smile","sparky","spring","steven","success","sunshine","victoria","whatever","zapata","Internet","amanda","andy","angel","august","barney","biteme","boomer","brian","casey","coke","cowboy",
            "delta","doctor","fisher","foobar","island","john","joshua","karen","marley","orange","please","rascal","richard","sarah","scooter","shalom","silver","skippy","stanley","taylor","welcome","zephyr","aaaaaa","abc","access","albert","alexander","andrea",
            "anna","anthony","asdfjkl;","ashley","basf","basketball","beavis","black","bob","booboo","bradley","brandon","buddy","caitlin","camaro","charlie","chicken","chris","cindy","cricket","dakota","dallas","daniel","david","debbie","dolphin","elephant","emily",
            "fish","fred","friend","fucker","ginger","goodluck","hammer","heather","help","iceman","jason","jessica","jesus","joseph","jupiter","justin","kevin","knight","lacrosse","lakers","lizard","madison","mary","mother","muffin","murphy","newuser","nirvana",
            "none","paris","pat","pentium","phoenix","picture","rainbow","sandy","saturn","scott","shannon","shithead","skeeter","sophie","special","stephanie","stephen","steve","sweetie","teacher","tennis","tommy","topgun","tristan","wally","william","wilson","alpha","amber",
            "angela","angie","archie","asdf","blazer","booger","charles","christin","claire","control","danny","dennis","digital","disney","dog","duck","duke","edward","elvis","felix","flipper","floyd","franklin","frodo","guest","honda","horses","hunter","indigo","info",
            "james","jasper","jeremy","joe","julian","kelsey","killer","kingfish","lauren","marie","maryjane","matrix","maverick","mayday","mercury","micro","mitchell","morgan","mountain","niners","nothing","oliver","peace","peanut","pearljam","phantom","popcorn","princess",
            "psycho","pumpkin","purple","randy","rebecca","reddog","robert","rocky","roses","salmon","sam","samson","sharon","sierra","smokey","startrek","steelers","stimpy","sunflower","superman","support","sydney","techno","telecom","walter","willie","willow","winner",
            "ziggy","zxcvbnm","absolut","alaska","alexis","alice","animal","apples","backup","barbara","benjamin","bill","billy","blue","bluebird","bobby","bonnie","bubba","camera","chocolate","clark","claudia","cocacola","compton","connect","cookie","cruise","deliver",
            "douglas","dreamer","dreams","duckie","eagles","eddie","einstein","enter","explorer","faith","family","ferrari","fire","flamingo","flip","flower","foxtrot","francis","freddy","friday","froggy","galileo","giants","gizmo","global","goofy","gopher","hansolo",
            "hendrix","henry","herman","homer","honey","house","houston","iguana","indiana","insane","inside","irish","ironman","jake","jane","jasmin","jeanne","jerry","jim","joey","justice","katherine","kermit","kitty","koala","larry","leslie","logan","lucky","mark","martin",
            "matt","minnie","misty","mitch","mom","mouse","nancy","nascar","nelson","netware","pantera","parker","passwd","penguin","peter","phil","phish","piano","pizza","prince","punkin","pyramid","rain","raymond","red","robin","roger","rosebud","royal","running","sadie","sasha","security",
            "sergei","sheena","sheila","skiing","snapple","snowball","sparrow","spencer","spike","star","stealth","student","sun","sunny","sylvia","tamara","taurus","tech","teresa","theresa","thunderbird","tigers","tony","toyota","training","travel","truck","tuesday","victory","video","volvo","wesley","whisky",
            "winnie","winter","wolves","zorro","!@#$%","Anthony","Friday","Hendrix","Joshua","Matthew","October","Taurus","Tigger","aaa","aaron","abby","abcdef","adidas","adrian","alexandr","alfred","arthur","athena","austin","awesome","badger","bamboo","beagle","bears","beatles","beautiful","beaver","benny",
            "bigmac","bingo","bitch","blonde","boogie","boston","brenda","bright","bubbles","buffy","button","buttons","cactus","candy","captain","carlos","caroline","carrie","casper","catalog","challenge","chance","charity","charlotte","cheese","cheryl","chloe","clancy","clipper","coltrane","compaq","conrad","cooper",
            "cooter","copper","cosmos","cougar","cracker","crawford","crystal","curtis","cyclone","cyrano","dan","dance","dawn","dean","deutsch","diablo","dilbert","dollars","dookie","doom","dumbass","dundee","e-mail","elizabeth","eric","europe","export","farmer","firebird","fletcher","fluffy","ford","fountain",
            "fox","france","friends","frog","fuckoff","gabriel","gabriell","galaxy","gambit","garden","garfield","garlic","garnet","genesis","genius","godzilla","goforit","golfer","goober","grace","grateful","greenday","groovy","grover","guitar","hacker","harry","hazel","hector","herbert","hoops","horizon","hornet",
            "howard","icecream","imagine","impala","informix","jack","janice","jasmine","jeanette","jeffrey","jenifer","jenni","jewels","joker","julie","junior","kathleen","keith","kelly","kennedy","knicks","lady","ledzep","lee","leonard","lestat","library","lincoln","lionking","london","louise","lucy","maddog",
            "mailman","majordomo","mantra","margaret","mariposa","market","marlboro","marty","mensuck","mercedes","metal","metallic","midori","mikey","millie","mirage","mmm","molly","monet","monica","monopoly","mookie","moose","moroni","music","naomi","nathan","nesbitt","news","nguyen","nicholas","nicole","nimrod",
            "october","olive","olivia","one","online","open","oscar","oxford","pacific","painter","peaches","penelope","pepsi","pete","petunia","philip","photo","pickle","player","poiuyt","porsche","porter","ppp","puppy","python","quality","quest","raquel","raven","remember","republic","research","robbie",
            "roman","rugby","runner","russell","ryan","sailing","sailor","samantha","savage","sbdc","scarlett","school","sean","seven","sheba","shelby","shit","shoes","simba","simple","skipper","smiley","snake","snickers","sniper","snoopdog","snowman","sonic","spitfire","sprite","spunky","starwars","station",
            "stella","stingray","storm","stormy","stupid","sumuinen","sunrise","supra","surfer","susan","tammy","tango","tanya","tara","temp","testing","theboss","theking","thumper","tina","tintin","tomcat","trebor","trek","trevor","tweety","unicorn","valentine","valerie","vanilla","veronica","victor","vincent",
            "viper","warrior","warriors","weasel","wheels","wilbur","winston","wisdom","wombat","xanadu","xavier","xxxx","yellow","zaphod","zeppelin","zeus","Andrew","Broadway","Champs","Family","Fisher","Friends","Jeanne","Killer","Knight","Master","Michael","Michelle","Pentium","Pepper","Raistlin","Sierra","Snoopy",
            "Tennis","Tuesday","abacab","abcd","abcdefg","abigail","account","ace","acropolis","adam","adi","allison","alpine","amy","anders","anita","annette","antares","apache","apollo","aragorn","arizona","arnold","arsenal","asdfasdf","asdfg","asdfghjk","avenger","avenir","baby","babydoll","bach","bailey",
            "banana","barry","basil","basket","bass","beaner","beast","beatrice","beer","bella","ben","bertha","bigben","bigdog","biggles","bigman","binky","biology","bishop","bliss","blondie","blowfish","bluefish","bmw","bobcat","bosco","boss","braves","brazil","bridges","bruce","bruno","brutus",
            "buck","buffalo","bugsy","bull","bulldog","bullet","bullshit","bunny","business","butch","butler","butter","california","cannondale","canon","carebear","carol","carole","cassie","castle","catalina","catherine","catnip","cccccc","celine","center","champion","chanel","chaos","chicago","chico","chip","christian",
            "christy","church","cinder","civil","colleen","colorado","columbia","commander","connie","content","cook","cookies","cooking","cordelia","corona","cowboys","coyote","craig","creative","crow","cuddles","cuervo","cutie","cyber","daddy","daisie","daisy","danielle","database","davids","deadhead","death","denali",
            "denis","depeche","derek","design","destiny","diana","diane","dickens","dickhead","digger","dodger","don","donna","dougie","draft","dragonfly","dylan","eagle","eclipse","electric","emerald","emmitt","entropy","etoile","excalibur","express","farout","farside","feedback","fender","fidel","fiona","fireman",
            "firenze","flash","fletch","florida","flowers","fool","foster","fozzie","francesco","francine","francois","frank","french","fuckface","fun","gargoyle","gasman","gemini","general","gerald","germany","gilbert","goaway","gold","golden","goldfish","goose","gordon","graham","grant","graphic","gregory","gretchen",
            "gunner","hannah","harold","harrison","harvey","hawkeye","heaven","heidi","helen","helena","hell","herzog","hithere","hobbit","huey","ibanez","idontknow","image","integra","intern","intrepid","ireland","irene","isaac","isabel","jackie","jackson","jaguar","jamaica","japan","jeff","jessie","jethrotull",
            "joel","johan","johnny","judith","julia","jumanji","jussi","kangaroo","kathy","keepout","kenneth","kidder","kim","kimberly","king","kingdom","kirk","kitkat","kramer","kris","kristen","lambda","laura","laurie","law","lawrence","lawyer","legend","leon","liberty","light","lindsay","lindsey",
            "lisa","liverpool","logical","lola","lonely","lorrie","louis","lovely","loveme","lucas","m","madonna","mail","major","malcolm","malibu","marathon","marcel","mariah","marilyn","mariner","mario","marvin","maurice","max","maxine","maxwell","me","media","meggie","melanie","melissa","melody",
            "merlot","mexico","michele","midnight","midway","miki","mine","miracle","misha","mishka","mmouse","monique","montreal","moocow","moon","moore","mopar","morris","mort","mortimer","mulder","nautica","nellie","nermal","new","newton","nicarao","nick","nina","nissan","norman","notebook","ocean",
            "olivier","ollie","olsen","opera","opus","oranges","oregon","orion","overkill","pacers","packer","panda","pandora","panther","passion","patricia","pearl","peewee","pencil","penny","people","percy","person","petey","picard","picasso","pierre","pinkfloyd","pit","plus","polar","polaris","police",
            "polo","poppy","power","predator","preston","primus","prometheus","public","queen","queenie","quentin","radio","ralph","random","rangers","raptor","rastafarian","reality","redrum","remote","reptile","reynolds","rhonda","ricardo","ricky","river","roadrunner","rob","robinhood","robotech","rocknroll","rodeo","rolex",
            "ronald","rouge","roxy","roy","ruby","ruthie","sabrina","sakura","salasana","sally","sampson","samuel","sandra","santa","sapphire","scarecrow","scarlet","scorpio","scottie","scout","scruffy","seattle","serena","sergey","shanti","shark","shogun","simon","singer","skibum","skull","skunk","skywalker",
            "slacker","smashing","smiles","snowflake","snowski","snuffy","soleil","sonny","sound","spanky","speedy","spider","spooky","stacey","start","starter","stinky","strawberry","stuart","sugar","sunbird","sundance","superfly","suzanne","suzuki","swimmer","swimming","system","taffy","tarzan","tbird","teddy","teddybear",
            "teflon","temporal","terminal","terry","the","theatre","thejudge","thunder","thursday","time","tinker","toby","today","tokyo","tootsie","tornado","tracy","tree","tricia","trident","trojan","trout","truman","trumpet","tucker","turtle","tyler","utopia","vader","val","valhalla","visa","voyager",
            "warcraft","warlock","warren","water","wayne","wendy","williams","willy","windsurf","winona","wolf","woody","woofwoof","wrangler","wright","www","xcountry","xfiles","xxxxxx","y","yankees","yoda","yukon","yvonne","zebra","zenith","zigzag","zombie","zxcvb","zzz","Abcdefg","Alexis","Alpha",
            "Animals","Ariel","BOSS","Bailey","Bastard","Beavis","Bismillah","Bonzo","Booboo","Boston","Canucks","Cardinal","Carol","Celtics","ChangeMe","Charlie","Chris","Computer","Cougar","Creative","Curtis","Daniel","Darkman","Denise","Dragon","Eagles","Elizabeth","Esther","Figaro","Fishing","Fortune","Freddy","Gandalf",
            "Geronimo","Gingers","Golden","Goober","Gretel","HARLEY","Hacker","Hammer","Harley","Heather","Henry","Hershey","Homer","Jackson","Janet","Jennifer","Jersey","Jessica","Joanna","Johnson","Jordan","KILLER","Katie","Kitten","Liberty","Lindsay","Lizard","Madeline","Margaret","Maxwell","Mellon","Merlot","Metallic",
            "Money","Monster","Montreal","Newton","Nicholas","Noriko","Paladin","Pamela","Password","Peaches","Peanuts","Peter","Phoenix","Piglet","Pookie","Princess","Purple","Rabbit","Raiders","Random","Rebecca","Robert","Russell","Sammy","Saturn","Service","Shadow","Sidekick","Skeeter","Smokey","Sparky","Speedy","Sterling",
            "Steven","Summer","Sunshine","Superman","Sverige","Swoosh","Taylor","Theresa","Thomas","Thunder","Vernon","Victoria","Vincent","Waterloo","Webster","Willow","Winnie","Wolverine","Woodrow","World","aa","aaaa","aardvark","abbott","abcde","accord","active","acura","adg","admin","adrock","aerobics","africa",
            "agent","airborne","airwolf","alfaro","ali","alicia","alien","aliens","alina","aline","alison","allegro","allen","allstate","aloha","altamira","althea","altima","amazing","america","amour","anderson","andre","andrew!","andromed","angels","ann","anne","anneli","annie","anything","applepie","april",
            "aptiva","aqua","aquarius","ariane","ariel","arlene","arrow","artemis","asdf;lkj","asdfjkl","ashraf","ashton","assmunch","asterix","attila","autumn","avatar","ayelet","aylmer","babes","bambi","baraka","barbie","barn","barnyard","barrett","bart","bartman","bball","beaches","beanie","beans","beasty",
            "beauty","bebe","becca","belgium","belize","belle","belmont","benji","benson","beowulf","bernardo","berry","beryl","best","beta","betacam","betsy","betty","bharat","bichon","bigal","bigboss","bigred","biker","bilbo","bills","bimmer","bioboy","biochem","birdie","birdy","birthday","biscuit",
            "bitter","biz","blackjack","blah","blanche","blinds","blitz","blood","blowjob","blowme","blueeyes","bluejean","blues","boat","bogart","bogey","bogus","bombay","boobie","boots","bootsie","boulder","bourbon","boxer","boxers","bozo","brain","branch","brandi","brent","brewster","bridge","britain",
            "broker","bronco","bronte","brooke","brother","bryan","bubble","bucks","buddha","budgie","buffett","bugs","bulls","burns","burton","butterfly","buzz","byron","calendar","calgary","camay","camel","camille","campbell","camping","cancer","canela","cannon","car","carbon","carl","carnage","carolyn",
            "carrot","cascade","cat","catfish","cathy","catwoman","cecile","celica","cement","cessna","chad","chainsaw","chameleon","chang","change","chantal","charger","chat","cherry","chess","chiara","chiefs","china","chinacat","chinook","chouette","christmas","christopher","chronos","chuck","cicero","cinema","circuit",
            "cirque","cirrus","civic","clapton","clarkson","class","claude","claudel","cleo","cliff","clock","clueless","cobain","cobra","cody","colette","college","color","colors","comet","concept","concorde","confused","cool","coolbean","cora","corky","cornflake","corvette","corwin","cosmo","country","courier",
            "cows","crescent","cross","crowley","crusader","cthulhu","cuda","cunningham","cunt","cupcake","current","cutlass","cynthia","daedalus","dagger","daily","dale","dammit","damogran","dana","dancer","daphne","darkstar","darren","darryl","darwin","datatrain","daytek","dead","deborah","december","decker","deedee",
            "deeznuts","def","delano","delete","demon","denise","denny","desert","deskjet","detroit","devil","devine","devon","dexter","dharma","dianne","diesel","dillweed","dim","dipper","director","disco","dixie","dixon","doc","dodgers","dogbert","doggy","doitnow","dollar","dolly","dominique","domino",
            "dontknow","doogie","doors","dork","doudou","doug","downtown","driver","dude","dudley","dutch","dutchess","dwight","easter","eastern","edith","edmund","effie","eieio","eight","element","elissa","ella","ellen","elliot","elsie","empire","engage","enigma","enterprise","erin","escort","estelle",
            "eugene","evelyn","excel","explore","eyal","faculty","fairview","fatboy","faust","felipe","fenris","ferguson","ferret","ferris","finance","fireball","first","fishes","fishhead","fishie","flanders","fleurs","flight","flowerpot","flute","fly","flyboy","flyer","forward","franka","freddie","frederic","free",
            "freebird","freeman","frisco","fritz","froggie","froggies","frogs","frontier","fucku","fugazi","funguy","funtime","future","fuzz","gabby","gaby","gaelic","gambler","games","gammaphi","garcia","garfunkel","garth","gary","gaston","gateway","georgia","german","getout","ggeorge","ghost","gibbons","gibson",
            "gigi","gilgamesh","giselle","gmoney","goat","goblin","goblue","godiva","goethe","gofish","gollum","gone","good","gramps","grandma","gravis","gray","greed","greg","gremlin","greta","gretzky","grizzly","grumpy","guess","guido","gumby","gustavo","haggis","haha","hailey","hal","halloween",
            "hallowell","hamid","hamilton","hamlet","hank","hanna","hanson","happyday","hardcore","haro","harriet","harris","harvard","hawk","health","heart","hedgehog","heikki","helene","hellohello","helper","hermes","heythere","highland","hilda","hillary","histoire","history","hitler","hobbes","holiday","holly","homerj",
            "hongkong","hoosier","hootie","hope","horse","hosehead","hotrod","huang","hudson","hugh","hugo","hummer","huskies","hydrogen","i","idiot","iforget","ilmari","iloveu","impact","indonesia","ingvar","insight","instruct","integral","iomega","irina","iris","irmeli","isabelle","israel","italia","italy",
            "izzy","jacob","jakey","jamesbond","jamie","jamjam","jan","jazz","jean","jedi","jeepster","jennie","jenny","jensen","jer","jesse","jester","jethro","jimbob","jimi","jimmy","joanie","joanna","joelle","jordie","jorge","josee","josh","journey","joy","joyce","jubilee","juhani",
            "jules","julien","juliet","jumbo","jump","junebug","juniper","justdoit","kalamazo","kali","karin","karine","karma","kat","kate","katerina","katie","kayla","kcin","keeper","keller","kendall","kenny","kerala","kerrya","ketchup","khan","kids","kings","kissme","kitten","kittycat","kiwi",
            "kkkkkk","kleenex","kombat","kristi","kristine","labtec","laddie","ladybug","lamer","lance","laser","laserjet","laurel","lawson","leader","leaf","leblanc","legal","leland","lemon","leo","lester","letter","letters","lev","libra","life","lights","lima","lionel","lions","lissabon","little",
            "liz","lizzy","logger","logos","loislane","loki","lolita","lonestar","longer","longhorn","looney","loren","lori","lorna","loser","lost","lotus","lou","lovers","loveyou","lucia","lucifer","macha","macross","maddie","madmax","madoka","magnum","maiden","maine","makeitso","mallard","manageme",
            "manson","manuel","marc","marcus","maria","marielle","marine","marino","marshall","mart","martha","math","mattingly","maxmax","meatloaf","mech","mechanic","medical","megan","meister","melina","memphis","mercer","merde","mermaid","merrill","miami","michal","michel","michigan","michou","mickel","microsoft",
            "midvale","mikael","milano","miles","millenium","million","minou","miranda","miriam","mission","mmmmmm","mobile","mobydick","modem","mojo","monroe","montana","montrose","monty","moomoo","moonbeam","morecats","morpheus","motor","motorola","movies","mowgli","mozart","munchkin","murray","muscle","nadia","nadine", 
            "napoleon","nation","national","neil","neko","nesbit","nestle","neutrino","newaccount","newlife","nichole","nicklaus","nightshadow","nightwind","nike","nikita","nikki","nintendo","nisse","nokia","nomore","nopass","normal","norton","nouveau","novell","noway","nugget","numbers","nurse","nutmeg","oaxaca","obiwan",
            "obsession","ohshit","omega","openup","orchid","oreo","orlando","orville","otter","ozzy","paagal","packard","packers","packrat","paint","paloma","pam","pancake","panic","papa","paradigm","park","parola","parrot","partner","pascal","pass","patches","patriots","paula","pauline","pavel","payton",
            "peach","peanuts","peggy","pekka","perfect","performa","perry","peterk","peterpan","phialpha","philips","phillips","phishy","phone","pianoman","pianos","pierce","pigeon","pink","pioneer","pipeline","pirate","pisces","plato","play","playboy","pluto","poetic","poetry","pole","pontiac","pookey","pope",
            "popeye","prayer","precious","prelude","premier","print","printing","prof","provider","puddin","pulsar","pussy","pyro","quebec","qwer","qwert","qwertyui","racer","racerx","rachelle","racoon","radar","rafiki","raleigh","ram","rambo","ratio","ravens","redcloud","redfish","redman","redskins","redwing",
            "redwood","reed","reggae","reggie","reliant","rene","renee","renegade","rescue","revolution","rex","reznor","rhino","rhjrjlbk","richards","richmond","riley","ripper","ripple","rita","robby","roberts","robocop","robotics","roche","rock","rockie","rockon","rogers","roland","rommel","roni","rookie",
            "rootbeer","rosie","rossigno","rufus","rugger","rush","rusty","ruthless","sabbath","sabina","safety","saigon","saint","samIam","samiam","sammie","sammy","samsam","sandi","sanjose","saphire","saskia","sassy","satori","saturday","schnapps","science","scooby","scoobydoo","scorpion","scotch","scotty","scouts",
            "scuba","search","seeker","seoul","september","server","services","sex","sexy","shaggy","shanghai","shanny","shaolin","shasta","shayne","shazam","shelly","shelter","sherry","ship","shirley","shorty","shotgun","sidney","sigmachi","signal","signature","simsim","sinatra","sirius","skate","skip","skydive",
            "skyler","slayer","sleepy","slick","slider","slip","smegma","smiths","smitty","smoke","smurfy","snakes","snapper","snoop","snow","solomon","sonics","sony","sophia","space","sparks","spartan","spazz","sphynx","spock","sponge","spoon","spot","sprocket","spurs","squash","stan","starbuck",
            "stargate","starlight","stars","steel","stephi","stevens","stewart","sting","stivers","stocks","stone","storage","stranger","strat","strato","stretch","strong","stud","studio","stumpy","sucker","suckme","sue","sultan","summit","sunfire","sunset","super","superstar","surfing","susanna","sutton","suzy",
            "swanson","sweden","sweetpea","sweety","swim","switzer","swordfish","t-bone","tab","tabatha","tacobell","taiwan","talon","tamtam","tanner","tapani","targas","target","tarheel","tasha","tata","tattoo","tazdevil","tequila","tester","testi","testtest","texas","thankyou","theend","thelorax","thisisit","thompson",
            "thorne","thrasher","tightend","tika","tim","timber","timothy","tinkerbell","tnt","tom","tool","topcat","topher","toshiba","total","tototo","toucan","transfer","transit","transport","trapper","trash","travis","tre","treasure","trees","tricky","trish","triton","trombone","trophy","trouble","trucker",
            "tucson","tula","turbo","twins","ultimate","unique","united","unity","unix","upsilon","ursula","vacation","valley","vampire","vanessa","vedder","velo","venice","venus","vermont","vette","vicki","vicky","vikram","violet","violin","virago","virgil","virginia","vision","visual","volcano","volley",
            "voodoo","vortex","waiting","walden","waldo","walleye","wanker","warner","webmaster","webster","wedge","weezer","western","whit","white","whitney","whocares","whoville","wibble","wildcat","will","wilma","wind","window","winniethepooh","wolfgang","wolverine","wonder","word","world","x-files","x-men","xanth",
            "xxxxxxxx","xyz","yamaha","yankee","yogibear","yolanda","yomama","yvette","zachary","zack","zebras","zepplin","zoltan","zoomer","zxc","zxcvbn","!@#$%^&","@#$%^&","Abcdef","Asdfgh","Casio","Changeme","FuckYou","Fuckyou","Gizmo","Hello","JSBach","Michel","PPP","Qwert","Qwerty","Windows","Zxcvb",
            "Zxcvbnm","action","advil","allo","amelie","anaconda","angus","artist","aspen","ass","asshole","ath","benoit","bernard","bernie","bigbird","bird","blizzard","bluesky","bonjour","booster","byteme","caesar","cardinal","carolina","cats","cedic","cesar","chandler","changeit","chapman","chevy","chiquita",
            "chocolat","christia","christoph","classroom","cloclo","coco","corrado","cougars","courtney","dasha","demo","dirk","dolphins","dominic","donkey","dusty","e","energy","fearless","fiction","forest","fubar","gator","gilles","glenn","go","gocougs","good-luck","graymail","guinness","hilbert","hola","home",
            "homebrew","hotdog","indian","jared","jimbo","jkm","johnson","jojo","josie","judy","koko","kristin","lloyd","lorraine","lulu","lynn","mac","macintosh","mailer","mars","maxime","memory","meow","mimi","mirror","nat","nebraska","nemesis","network","newcourt","nigel","niki","nite",
            "notused","oatmeal","patton","paul","pedro","planet","players","politics","pomme","portland","praise","property","protel","psalms","qwaszx","raiders","rancid","ruth","sales","salut","scrooge","shawn","shelley","skidoo","softball","spain","speedo","sports","sss","ssssss","steele","steph","stephani",
            "sunday","surf","sylvie","symbol","tiffany","tigre","toronto","trixie","undead","valentin","velvet","viking","walker","watson","young","zhongguo"};
    }
}