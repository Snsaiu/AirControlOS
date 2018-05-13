this is a interface folder and you can not modify here,this interface main function to convert data from other driver
like MCU or wifi.when you new create a class and inherit this interface ,you must implement two function that 'ParseData' 
and 'SendData',you can use a event 'ParseDataChangedEvent'.it is importance to notify other component to update data
