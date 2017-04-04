#!/usr/bin/env python 

""" 
A simple echo server,
to test tcp networking code
""" 

import socket 

host = '127.0.0.1' 
port = 50000 
backlog = 5 
size = 1024 
message="Hello World!"
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM) 
s.bind((host,port)) 
s.listen(backlog) 

while 1:
    client, address = s.accept() 
    print ("Client connected")
    client.send(message.encode('utf-8')) 

    while 1: 
        data = client.recv(size).rstrip('\r\n')
        if data: 
            if data=="quit":
                client.send("Bye!\n")
                client.close()
                break
            else:
                client.send("You just said: " + data + "\n") 

