using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using TMPro;
using System;

public class AuthManager : MonoBehaviour
{
    //FB Var
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    //Login Var
    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text warningLoginText;
    public TMP_Text confirmLoginText;

    //Regi Var
    [Header("Register")]
    public TMP_InputField usernameRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;


    public TMP_Text warningRegisterText;
    DatabaseReference mDatabaseRef;

    string userID;
    public GameObject loginUI;
    public GameObject registerUI;
    private void Awake()
    {
        // check to make sure necessary dependencies are present
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
       {
           dependencyStatus = task.Result;
           if (dependencyStatus == DependencyStatus.Available)
           {
               IntializeFirebase();

           }
           else
           {
               Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
           }
       });

    }
    private void writeNewUser(string userID, string name, string email, int token, int inv1, int inv2, int inv3, int inv4)
    {

        //mDatabaseRef.Child("users").Child(userID).SetRawJsonValueAsync(json);

        
        try
        {
            mDatabaseRef.Child("users").Child(userID).Child("username").SetValueAsync(name);
            mDatabaseRef.Child("users").Child(userID).Child("email").SetValueAsync(email);
            mDatabaseRef.Child("users").Child(userID).Child("token").SetValueAsync(token);
            mDatabaseRef.Child("users").Child(userID).Child("Inv1").SetValueAsync(inv1);
            mDatabaseRef.Child("users").Child(userID).Child("Inv2").SetValueAsync(inv2);
            mDatabaseRef.Child("users").Child(userID).Child("Inv3").SetValueAsync(inv3);
            mDatabaseRef.Child("users").Child(userID).Child("Inv4").SetValueAsync(inv4);

        }catch (ArgumentException e)
        {
            print(e);
        }
    }
    private void IntializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = FirebaseAuth.DefaultInstance;
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;

    }

    public void LoginButton()
    {
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
    }

    public void RegisterButton()
    {
        StartCoroutine(Register(emailRegisterField.text, passwordRegisterField.text, usernameRegisterField.text));
    }

    public void loginSwitch()
    {
        loginUI.SetActive(true);
        registerUI.SetActive(false);
    }
    private IEnumerator Login(string _email, string _password)
    {

        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            warningLoginText.text = message;
        }

        else
        {
            User = LoginTask.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            warningLoginText.text = "";
            confirmLoginText.text = "Logged In";
            SceneManager.LoadScene(sceneName: "MenuScene");

        }
    }

                
                

    private IEnumerator Register(string _email, string _password, string _username)
    {
        if (_username == "")
        {
            warningRegisterText.text = "Missing Username";
        }

        else if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            warningRegisterText.text = "Passwords Do Not Match!";
        }
        else
        {
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email Already In Use";
                        break;
                }
                warningRegisterText.text = message;
            }
            else
            {
                User = RegisterTask.Result;

                if (User != null)
                {
                    UserProfile profile = new UserProfile { DisplayName = _username };
                    var ProfileTask = User.UpdateUserProfileAsync(profile);

                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {

                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        warningRegisterText.text = "Username Set Failed!";
                    }
                    else
                    {
                        warningRegisterText.text = "Register Success!";
                        yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);
                        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
                        Firebase.Auth.FirebaseUser cUser = auth.CurrentUser;
                        string key = cUser.UserId;
                        print(key);
                        writeNewUser(key, _username, _email, 5000, 0, 0, 0, 0);
                        UIManager.man.LoginScreen();
                    }
                }
            }
        }
    }

}