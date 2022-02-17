package com.example.sampletab2;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.MenuItem;
import android.widget.Toast;

import com.google.android.material.bottomnavigation.BottomNavigationView;

public class MainActivity extends AppCompatActivity {

    com.example.sampletab2.Fragment1 fragment1;
    com.example.sampletab2.Fragment2 fragment2;
    com.example.sampletab2.Fragment3 fragment3;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        fragment1= new com.example.sampletab2.Fragment1();
        fragment2= new com.example.sampletab2.Fragment2();
        fragment3=new com.example.sampletab2.Fragment3();

        //앱이 실행되었을 떄 첫 번째 프래그먼트가 보이도록
        getSupportFragmentManager()
                .beginTransaction().replace(R.id.container, fragment1).commit();

        BottomNavigationView bottomNavigation= findViewById(R.id.bottom_navigation);
        bottomNavigation.setOnNavigationItemSelectedListener(
                new BottomNavigationView.OnNavigationItemSelectedListener(){
                    @Override
                    public boolean onNavigationItemSelected(@NonNull MenuItem item){
                        switch (item.getItemId()){
                            case R.id.tab1:
                                Toast.makeText(getApplicationContext(),"첫 번째 탭 선택됨",Toast.LENGTH_LONG).show();
                                getSupportFragmentManager().beginTransaction().replace(R.id.container,fragment1).commit();
                                return true;

                            case R.id.tab2:
                                Toast.makeText(getApplicationContext(),"두 번째 탭 선택됨",Toast.LENGTH_LONG).show();
                                getSupportFragmentManager().beginTransaction().replace(R.id.container,fragment2).commit();
                                return true;

                            case R.id.tab3:
                                Toast.makeText(getApplicationContext(), "세 번째 탭 선택됨", Toast.LENGTH_LONG).show();
                                getSupportFragmentManager().beginTransaction().replace(R.id.container,fragment3).commit();

                                return true;

                        }
                        return false;
                    }

                }
        );
    }
}