package crynyd.mapa;

import android.support.v4.app.FragmentActivity;
import android.os.Bundle;

import com.google.android.gms.maps.*;
import com.google.android.gms.maps.model.*;
import android.app.Activity;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;

public class MapsActivity extends FragmentActivity {

    private GoogleMap mMap; // Might be null if Google Play services APK is not available.

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_maps);
        setUpMapIfNeeded();
    }

    @Override
    protected void onResume() {
        super.onResume();
        setUpMapIfNeeded();
    }

    /**
     * Sets up the map if it is possible to do so (i.e., the Google Play services APK is correctly
     * installed) and the map has not already been instantiated.. This will ensure that we only ever
     * call {@link #setUpMap()} once when {@link #mMap} is not null.
     * <p/>
     * If it isn't installed {@link SupportMapFragment} (and
     * {@link com.google.android.gms.maps.MapView MapView}) will show a prompt for the user to
     * install/update the Google Play services APK on their device.
     * <p/>
     * A user can return to this FragmentActivity after following the prompt and correctly
     * installing/updating/enabling the Google Play services. Since the FragmentActivity may not
     * have been completely destroyed during this process (it is likely that it would only be
     * stopped or paused), {@link #onCreate(Bundle)} may not be called again so we should call this
     * method in {@link #onResume()} to guarantee that it will be called.
     */
    private void setUpMapIfNeeded() {
        // Do a null check to confirm that we have not already instantiated the map.
        if (mMap == null) {
            // Try to obtain the map from the SupportMapFragment.
            mMap = ((SupportMapFragment) getSupportFragmentManager().findFragmentById(R.id.map))
                    .getMap();
            // Check if we were successful in obtaining the map.
            if (mMap != null) {
                setUpMap();
            }
        }
    }

    /**
     * This is where we can add markers or lines, add listeners or move the camera. In this case, we
     * just add a marker near Africa.
     * <p/>
     * This should only be called once and when we are sure that {@link #mMap} is not null.
     */


    private void setUpMap() {

        LatLng pos = new LatLng(21.120744, -101.667366);

        mMap.setMyLocationEnabled(true);
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(pos, 13));

        mMap.addMarker(new MarkerOptions()
                .title("Estacionamiento Estrella")
                .snippet("$14.00 por hora 7:00 am – 10:00 pm  DISC CAM TECH  25 Lugares" )
                .position(pos));



        LatLng pos1 = new LatLng(21.122332, -101.667224);

        mMap.setMyLocationEnabled(true);
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(pos1, 13));

        mMap.addMarker(new MarkerOptions()
                .title("Estacionamiento Público San Antonio")
                .snippet("$20.00 por hora 10:00 am – 10:00 pm  6 Lugares")
                .position(pos1));



        LatLng pos2 = new LatLng(21.121650, -101.660084);

        mMap.setMyLocationEnabled(true);
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(pos2, 13));

        mMap.addMarker(new MarkerOptions()
                .title("Estacionamiento Público La Central")
                .snippet("$25.00 por hora 6:00 am – 12:00 am  DISC CAM TECH  20/26 Lugares")
                .position(pos2));



        LatLng pos3 = new LatLng(21.123971, -101.661092);

        mMap.setMyLocationEnabled(true);
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(pos3, 13));

        mMap.addMarker(new MarkerOptions()
                .title("Estacionamiento Killian")
                .snippet("$15.50 por hora 10:00 am – 11:30 pm  DISC CAM TECH  32/40 Lugares")
                .position(pos3));

        LatLng pos4 = new LatLng(21.119254, -101.679613);

        mMap.setMyLocationEnabled(true);
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(pos4, 13));

        mMap.addMarker(new MarkerOptions()
                .title("Estacionamiento público Altamirano")
                .snippet("$12.00 pesos por hora de 9:00 AM a 10:00 PM DISC TECH 17 Lugares")
                .position(pos4));

        LatLng pos5 = new LatLng(21.119517, -101.680799);

        mMap.setMyLocationEnabled(true);
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(pos5, 13));

        mMap.addMarker(new MarkerOptions()
                .title("Estacionamiento pública Emiliano Zapata")
                .snippet("$10.00 pesos por hora de 6:30 AM a 10:00 PM CAM 30 Lugares")
                .position(pos5));

        LatLng pos6 = new LatLng(21.118924, -101.683278);

        mMap.setMyLocationEnabled(true);
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(pos6, 13));

        mMap.addMarker(new MarkerOptions()
                .title("Estacionamiento del centro")
                .snippet("$10.00 pesos por hora de 9:00 AM a 8:00 PM CAM TECH 23/35 disponibles")
                .position(pos6));


        LatLng pos7 = new LatLng(21.118467, -101.679991);

        mMap.setMyLocationEnabled(true);
        mMap.moveCamera(CameraUpdateFactory.newLatLngZoom(pos7, 13));

        mMap.addMarker(new MarkerOptions()
                .title("Estacionamiento Guadalupe")
                .snippet("$10.00 pesos por hora de 10:30AM a 9:30PM DISC TECH CAM 20/23 disponibles")
                .position(pos7));


    }
}
