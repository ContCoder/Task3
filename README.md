**TASK #3** (FOR ALL GROUPS)

For those who have already sent #1 and #2.

Using the language of your choice—from the C#/JavaScript/TypeScript/Java/PHP/Ruby/Python/Rust set, please—to write ***a console script*** that implements a ***generalized*** non-transitive dice game (with the supports of arbitrary values on the dice). Of course, _it's recommended to use the language of your "specialization,"_ i.e. C# or JavaScript/TypeScript, but it's not required.

When launched with ***command line parameters***—arguments to the `main` or `Main` method in the case of Java or C# correspondingly, `sys.argv` in Python, `process.argv` in Node.js, etc.—it accepts 3 or more strings, each containing 6 comma-separated integers. E.g., `python game.py 2,2,4,4,9,9 6,8,1,1,8,6 7,5,3,7,5,3`. In principle, you may support any number of faces on a dice, like 4 or 20, but it's not very important.

If the arguments are incorrect, you must display a neat error message,not a stacktrace—what exactly is wrong and an example of how to do it right (e.g., user specified only two dice or no dice at all, used non-integers, etc.). All messages should be in English.

Important: ***dice configuration is passed as command line arguments***; you don't "parse" it from the input stream.

The victory is defined as follows—computer and user select different dice, perform their "rolls," and whoever rolls higher wins. 

The first step of the game is to determine who makes the first move. You have to prove to the user that choice is fair (it's not enough to generate a random bit 0 or 1; the user needs a proof of the fair play). 

When the users make the roll, they select dice using CLI "menu" and "generate" a random value with the help of the computer. The options consist of all the available dice, the exit (cancel) option, and the help option.

When the computer makes the roll, it selects dice and "generates" a random value. 

Of course, "random" generation is also should be provable fair.
------------------------------------------------------------------
OK, just a few more hint/explanations about #3:
1. You **have to** use base class libraries and 3rd-party libaries for the implementation (esp. for console table generation).
2. Your code generates a secret key first, then it generates a random value and then show **only** HMAC to the user. After that the user generates their value. Then your code shows its number, sum, generated move as well as the secret key. And then user can check the fact that the computer value and the secret key give together exactly the same HMAC that was shown before.
3. You may generate a link that allows HMAC calculation to simplify the "check" for the user, but it's not required. And definitely your don't need to create a separate app to check HMAC, the idea is that user may not trust the code you wrote.
4. A value from the computer and a value from the user are needed to make a single roll. So, the computer have to generate 3 numbers (0..1 to determine who select the dice first, 0..5 for the user roll and 0..5 for the computer roll) and the user have to enter 3 numbers (0..1 to determine who select the dice first, 0..5 for own roll and 0..5 for the computer roll). Or, in other words, each generation requires the participation of both parties, the user and the computer. Of course, there will be also 3 keys and 3 HMAC per game in total.
5. The “protocol” with HMAC allow to generate 2 numbers (one by computer, one by user) “in parallel”, independently — when user selects their  number, he/she doesn’t know the computer selection yet, but the computer cannot change its selection after user’s moves. So, the result depends on computer number AND user number. And it’s necessary to “glue” two numbers to get a uniform distribution. The simplest way is to use modular addition.
------------------------------------------------------------------
@everyone 

***About Task #3***

I posted some explanation about hashes and HMACs here in the  https://discord.com/channels/950701840901746708/1396050646146220114/1396740657476927508 channel. Please, note that you need to use already implemented HMAC function, not to recreate it from hash for yourself, because there are some tricky non-obvious details (more on that this Friday).
-------------------------------------------------------------------
You may use OBS Studio to record video. It's free, has a lot of features, however is simple and easy-to-se, and also work on multiple platforms.

Remember, the video should: 
* be publicly accessible,
* has landscape orientation,
* has reasonable resolution (not less that 1080p),
* has reasonable compression quality (_all console output should be legible_; don't forget to open terminal in full screen).

Вы можете использовать OBS Studio для записи видео. Бесплатно, много возможностей, просто в использование и работает на многих платформах.

Помните, что видео должно:
* быть публично доступным,
* иметь горизонтальную ориентацию,
* иметь адекватное разрешение (не меньше 1080p),
* использовать адекватное качество (_весь консольный вывод должен быть читабельным_; не забудьте открыть терминал на полный экран).