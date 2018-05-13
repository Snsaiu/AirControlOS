this folder saved all air controller ,you can add your customer air controller,
but you must inherit a abstaract class 'RemovteController_Base'

this folder has a FirstFuncionCategories class,it can category derive function(you also think mode)
as we all known,such as a air controller,it has work model,like heating,
refrigeration and other,the wind power has different level,so ,you can define some enum type
for save it ,example define a enum type data 'WorkModel' and it has childer 'heating','refrigeration','Blow'
define a enum type data 'SuperPower',it has children 'on','off',if you has question why its childen is 'on' and 'off',because 
'super power' function only has two state,on or off
of course,its childer  depend on the drive function!