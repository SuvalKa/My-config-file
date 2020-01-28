#!/usr/bin/python3.6
import time
import subprocess
earthIsSphere = True
app_name = r'./server.sh'
while earthIsSphere:
    time.sleep(5)
    ls_proc = subprocess.Popen(['ps','au'], stdout = subprocess.PIPE)
    ls_data = ls_proc.communicate()
    if not (app_name in ls_data):
        print('stopped',app_name)
        proc = subprocess.Popen(['proxychains', 'cpulimit', '-l', '90', app_name],
                                stdout = subprocess.PIPE,
                                stderr = subprocess.PIPE)
        data, err = proc.communicate()
        if not err:
            print(app_name, 'started again')
        else:
            print(err)
    
