this folder content please not modify! 
this folder has a abstract class ,it is a air controller base class
it has some method ,you should implement;
it also has a dictionary type data ,it can save you air controller command
and when you add a command ,you must add a index for this command

when you define a remote controller instance(object),
you should a static class named[remoteControllerName]FunctionCategory,
it can category derive function(you also think mode)
as we all known,such as a air controller,it has work model,like heating,
refrigeration and other,the wind power has different level,so ,you can define some enum type
for save it ,example define a enum type data 'WorkModel' and it has childer 'heating','refrigeration','Blow'
define a enum type data 'SuperPower',it has children 'on','off',
if you has question why its childen is 'on' and 'off',because 
'super power' function only has two state,on or off
of course,its childer  depend on the drive function!