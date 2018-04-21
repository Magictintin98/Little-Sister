package lessalopards.littlesister;

import android.content.Intent;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

import com.firebase.ui.auth.AuthUI;
import com.firebase.ui.auth.IdpResponse;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.iid.FirebaseInstanceId;

import java.util.Arrays;
import java.util.Date;

import lessalopards.littlesister.DAO.UserDAO;

public class MainActivity extends AppCompatActivity {

    private static final int RC_SIGN_IN = 123;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Create and launch sign-in intent
        startActivityForResult(
                AuthUI.getInstance()
                        .createSignInIntentBuilder()
                        .setAvailableProviders(Arrays.asList(
                                new AuthUI.IdpConfig.EmailBuilder().build()))
                        .build(),
                RC_SIGN_IN);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if(requestCode == RC_SIGN_IN) {
            IdpResponse response = IdpResponse.fromResultIntent(data);
            if (resultCode == RESULT_OK) {
                //Successfully signed in
                FirebaseUser currentUser = FirebaseAuth.getInstance().getCurrentUser();
                new LoadUserAsync(currentUser).execute();
            } else {
                //Sign in failed, check response for error code
            }
        }
    }

    @Override
    public void onBackPressed() {
        Intent startMain = new Intent(Intent.ACTION_MAIN);
        startMain.addCategory(Intent.CATEGORY_HOME);
        startMain.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
        startActivity(startMain);
    }

    private class LoadUserAsync extends AsyncTask<Void, Void, Integer> {
        private FirebaseUser user;

        private LoadUserAsync(FirebaseUser user) {
            this.user = user;
        }

        @Override
        protected Integer doInBackground(Void... voids) {
            UserDAO dao = new UserDAO();

            int response = dao.createUser(user.getUid(), user.getDisplayName(), user.getEmail(), true, 0, new Date(), FirebaseInstanceId.getInstance().getToken());
            if (response == 400) { //bad request
                response = dao.updateUser(user.getUid(), user.getDisplayName(), user.getEmail(), true, 0, new Date(), FirebaseInstanceId.getInstance().getToken());
            }

            return response;
        }
    }
}
