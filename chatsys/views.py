import pyrebase
from django.http import HttpResponse
from django.template import loader
from django.contrib.auth import authenticate,login,logout
from django.shortcuts import render, redirect
from .forms import SignUpForm
from django.contrib import messages
# Create your views here.
config={
  "apiKey": "AIzaSyDCem5mrJqfv3phnowuLY1EK5vIzHdiY1o",
  "authDomain": "chat-detection-system.firebaseapp.com",
  "databaseURL": "https://chat-detection-system-default-rtdb.asia-southeast1.firebasedatabase.app",
  "projectId": "chat-detection-system",
  "storageBucket": "chat-detection-system.appspot.com",
  "messagingSenderId": "464189634762",
  "appId": "1:464189634762:web:a726a15005bf5edd739c33",
  "measurementId": "G-3H7P7CP7T1"
}
firebase=pyrebase.initialize_app(config)
db=firebase.database()

def home(request):
    return render(request,'chatsys/home.html',{})

def signUp(request):
    if request.user.is_authenticated:
        return redirect('/')
    else:
    	if request.method =='POST':
    		form = SignUpForm(request.POST)
    		if form.is_valid():
    			form.save()
    			username = form.cleaned_data['username']
    			password = form.cleaned_data['password1']
    			user = authenticate(username=username, password=password)
    			login(request,user)
    			db.child("Bio").child(request.user).update({"bio":"Hello there!"})
    			return redirect('/')
    	else:
    		form = SignUpForm()
    	return render(request, 'chatsys/signup.html', {'form': form})

def logIn(request):
    if request.user.is_authenticated:
        return redirect('/')
    else:
        if request.method == 'POST':
            username = request.POST['username']
            password = request.POST['password']
            user = authenticate(request, username=username, password=password)
            if user is not None:
                login(request,user)
                return redirect('/')
            else:
                messages.error(request, 'Username or Password is Incorrect')
                return redirect('login')
        else:
            return render(request,'chatsys/login.html',{})

def logOut(request):
    if request.user.is_authenticated:
    	logout(request)
    return redirect('/')

def profile(request):
    data={}
    data["bio"]=db.child("Bio").child(request.user).get().val()['bio']
    data["imgurl"]="https://avatars.dicebear.com/api/initials/" +request.user.first_name+ "%20" +request.user.last_name+".svg"
    return render(request,'chatsys/profile.html',data)

